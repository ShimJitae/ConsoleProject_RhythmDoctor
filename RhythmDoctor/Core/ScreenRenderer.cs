using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Core
{
    // 실제 화면에 이미지(텍스트 파일)을 렌더링 해주는 코어
    public class ScreenRenderer
    {
        /// <summary>
        /// (int row, int col) pivot -> 이미지 제작을 시작할 피벗. 여기서부터 설정된 범위까지 문자열을 그려낸다.
        /// </summary>
        /// <param name="pivot"></param>

        Dictionary<RenderLayer, RenderingData> r_LayerDic;
        StringBuilder output = new StringBuilder();

        private ScreenRenderer()
        {
            r_LayerDic = new Dictionary<RenderLayer, RenderingData>();
            r_LayerDic.Add(RenderLayer.Background, new RenderingData());
            r_LayerDic.Add(RenderLayer.TimingBar, new RenderingData());
            r_LayerDic.Add(RenderLayer.Foreground, new RenderingData());
            r_LayerDic.Add(RenderLayer.UI, new RenderingData());
        }

        public void Render()
        {
            // 최종적으로 그려낼 output에 순서대로 이미지를 그려낸다.
            // output에 image_Background.Image 그리기
            // output에 image_TimingBar.Image 그리기
            // output에 image_Animation.Image 그리기
            // output에 image_UI.Image 그리기

            // 근데 반대로?
            // UI -> Foreground -> TimingBar -> Background 순서로 그리고
            // 이미 그려진 커서? 셀?을 bool타입으로 캐싱해두고,
            // 뒤로 갈수록 이미지 그려졌다고 하면, 렌더링(Console.Write)를 멈추는 것도 최적화에 좋지 않을까?

            // 그리고 _renderingPosition에 해당하는 위치에 실행하고 있는 콘솔 창에 그려내기
        }

        public void UpdateRD(RenderLayer rl, string imageName)
        {
            r_LayerDic[rl] = LoadRD(imageName);
        }

        /// <summary>
        /// 실제 이미지를 로드해오는 메서드
        /// </summary>
        /// <returns></returns>
        RenderingData LoadRD(string imageName)
        {
            // 이미지 로드 및 파싱

            // onRD에 이미지 적용

            return null;
        }
    }

    public class RenderingData
    { 
        // 로드해올 이미지의 이름
        public string ImageName { get; set; }
        // 이미지를 적용할 레이어
        // 실제로 그릴 이미지 데이터
        public StringBuilder Image { get; set; }
        // 이미지를 어느 부분부터 그리기 시작할지 렌더링 피벗
        public Vector2 RenderingPivot { get; set; }
        // 실제 콘솔창의 어느 위치에서부터 이미지를 그리기 시작할 것인지에 대한 포지션
        public Vector2 RenderingPosition { get; set; }

        public RenderingData()
        {
            ImageName = "";
            Image = new StringBuilder();
            RenderingPivot = new Vector2(0, 0);
            RenderingPosition = new Vector2(0, 0);
        }

        public RenderingData(string _ImageName, StringBuilder _Image, Vector2 _RenderingPivot, Vector2 _RenderingPosition)
        {
            ImageName = _ImageName;
            Image = _Image;
            RenderingPivot = _RenderingPivot;
            RenderingPosition = _RenderingPosition;
        }

        public bool Equals(Object obj)
        {
            if (!(obj is RenderingData rd))
                return false;

            if (ReferenceEquals(rd, null))
                return false;

            return ImageName == rd.ImageName;
        }

        public override int GetHashCode()
        {
            return ImageName != null ? ImageName.GetHashCode() : 0;
        }

        public static bool operator ==(RenderingData left, RenderingData right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(RenderingData left, RenderingData right)
        {
            return !(left == right);
        }
    }

    public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(int _y, int _x)
        {
            y = _y;
            x = _x;
        }
    }

    public enum RenderLayer
    {
        Background, // 게임의 뒷 배경
        TimingBar, // 플레이어가 입력을 넣을 타이밍을 보여주는 타이밍바
        Foreground, // 타이밍 바 앞에 그릴 이미지
        UI
    }
}
