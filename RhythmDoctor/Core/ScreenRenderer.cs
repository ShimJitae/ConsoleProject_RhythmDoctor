using RhythmDoctor.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RhythmDoctor.Core
{
    // 실제 화면에 이미지(텍스트 파일)을 렌더링 해주는 코어
    public class ScreenRenderer
    {
        // (int row, int col) pivot -> 이미지 제작을 시작할 피벗. 여기서부터 설정된 범위까지 문자열을 그려낸다.
        Dictionary<RenderLayer, RenderingData> r_LayerDic;
        Dictionary<RenderLayer, ConsoleColor> c_LayerDic;
        // 렌더링할 순서
        readonly RenderLayer[] renderOrder = new RenderLayer[] { RenderLayer.UI, RenderLayer.Foreground, RenderLayer.HitTiming, RenderLayer.TimingBar, RenderLayer.Background };

        public ScreenRenderer()
        {
            r_LayerDic = new Dictionary<RenderLayer, RenderingData>();

            r_LayerDic.Add(RenderLayer.Background, new RenderingData());
            r_LayerDic.Add(RenderLayer.TimingBar, new RenderingData());
            r_LayerDic.Add(RenderLayer.HitTiming, new RenderingData());
            r_LayerDic.Add(RenderLayer.Foreground, new RenderingData());
            r_LayerDic.Add(RenderLayer.UI, new RenderingData());

            c_LayerDic = new Dictionary<RenderLayer, ConsoleColor>();

            c_LayerDic.Add(RenderLayer.Background, ConsoleColor.Yellow);
            c_LayerDic.Add(RenderLayer.TimingBar, ConsoleColor.Red);
            c_LayerDic.Add(RenderLayer.HitTiming, ConsoleColor.White);
            c_LayerDic.Add(RenderLayer.Foreground, ConsoleColor.DarkRed);
            c_LayerDic.Add(RenderLayer.UI, ConsoleColor.Magenta);
        }

        List<StringBuilder> output = new List<StringBuilder>();
        public void Render()
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            if (width <= 0 || height <= 0)
                return;

            Console.SetCursorPosition(0, 0);

            for (int row = 0; row < height; row++)
            {
                if (row >= output.Count)
                {
                    output.Add(new StringBuilder());
                }

                StringBuilder sb = output[row];
                EnsureRowState(row, width);

                bool changed = false;

                for (int col = 0; col < width; col++)
                {
                    bool hasRenderChar = TryGetRenderChar(row, col, out char loadedChar);
                    char renderChar = hasRenderChar ? loadedChar : ' ';

                    if (sb[col] != renderChar)
                    {
                        sb[col] = renderChar;
                        changed = true;
                    }
                }

                if (!changed)
                    continue;

                Console.SetCursorPosition(0, row);

                // 마지막 칸까지 쓰면 콘솔이 자동 줄바꿈/스크롤될 수 있어서 한 칸을 비운다.
                int writeWidth = row == height - 1 ? Math.Max(0, width - 1) : width;
                Console.Write(sb.ToString(0, writeWidth));
            }

            void EnsureRowState(int row, int width)
            {
                StringBuilder sb = output[row];

                if (sb.Length > width)
                    sb.Length = width;

                while (sb.Length < width)
                {
                    sb.Append(' ');
                }
            }
        }

        bool TryGetRenderChar(int row, int col, out char renderChar)
        {
            renderChar = ' ';

            foreach (RenderLayer layer in renderOrder)
            {
                RenderingData rd = r_LayerDic[layer];

                if (rd.BlockRendering)
                    continue;

                // 이미지가 그려질 위치, row는 현재 띄워진 콘솔창의 세로길이, col은 가로길이
                // rd.StartR는 이미지를 그릴 시작 행, rd.StartC는 시작 열
                int imageRow = row - rd.StartR;
                int imageCol = col - rd.StartC;

                // imageRow나 imageCol이 콘솔창을 벗어나면 글자를 출력하지 않음
                if (imageRow < 0 || imageCol < 0)
                    continue;

                if (imageRow >= rd.ImageLines.Length)
                    continue;

                string imageLine = rd.ImageLines[imageRow];

                if (imageCol >= imageLine.Length)
                    continue;

                char imageChar = imageLine[imageCol];

                if (imageChar == ' ')
                    continue;

                renderChar = imageChar;
                return true;
            }

            return false;
        }

        public void UpdateRD(RenderLayer rl, string imageName, int startP_R, int startP_C)
        {
            // 로드한 이미지가 다른 경우 아예 새로운 RenderingData 객체를 만든다.
            if (!r_LayerDic[rl].ImageName.Equals(imageName))
            {
                r_LayerDic[rl] = new RenderingData(imageName, startP_R, startP_C);
            }
            // 이미지가 같은 경우, 시작점만 변경해준다.
            else
            {
                r_LayerDic[rl].StartR = startP_R;
                r_LayerDic[rl].StartC = startP_C;
            }
        }

        public void ActiveRendering(RenderLayer target, bool enabled)
        {
            r_LayerDic[target].BlockRendering = !enabled;
        }
    }

    public class RenderingData
    {
        // 로드해올 이미지의 이름
        public string ImageName { get; set; } = "";
        // 이미지를 적용할 레이어
        // 실제로 그릴 이미지 데이터
        public StringBuilder Image { get; set; } = new StringBuilder();
        public string[] ImageLines { get; set; } = Array.Empty<string>();
        // 실제 콘솔창의 어느 위치에서부터 이미지를 그리기 시작할 것인지에 대한 포지션
        public int StartR { get; set; }
        public int StartC { get; set; }
        //해당 레이어를 그릴지 안할지 여부를 정하는 bool 프로퍼티
        public bool BlockRendering { get; set; } = false;

        public RenderingData()
        {
            ImageName = "";
            Image = new StringBuilder();
            ImageLines = Array.Empty<string>();
            StartR = 0;
            StartC = 0;
        }

        public RenderingData(string _ImageName, int _StartR, int _StartC)
        {
            ImageName = _ImageName;
            string imageText = LoadImage(ImageName);
            Image = new StringBuilder(imageText);
            ImageLines = imageText.Replace("\r\n", "\n").Replace('\r', '\n').Split('\n');

            StartR = _StartR;
            StartC = _StartC;
        }

        /// <summary>
        /// 실제 이미지를 로드해오는 메서드
        /// </summary>
        string LoadImage(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                return string.Empty;

            // Images 폴더에서 {imageName}.txt 파일에서 텍스트를 로드해옴
            string fileName = Path.GetFileNameWithoutExtension(imageName) + ".txt";
            string projectImagePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);
            string outputImagePath = Path.Combine(AppContext.BaseDirectory, "Images", fileName);

            string imagePath = File.Exists(projectImagePath) ? projectImagePath : outputImagePath;

            if (!File.Exists(imagePath))
                throw new FileNotFoundException($"이미지 파일을 찾을 수 없습니다: {fileName}", imagePath);

            string imageText = File.ReadAllText(imagePath, Encoding.UTF8);

            return imageText;
        }
    }

    public enum RenderLayer
    {
        Background, // 게임의 뒷 배경
        TimingBar, // 타이밍바
        HitTiming, // 플레이어가 입력을 넣을 타이밍을 그려주는 레이어
        Foreground, // 타이밍 바 앞에 그릴 이미지
        UI
    }
}


