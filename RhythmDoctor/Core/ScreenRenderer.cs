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

        StringBuilder sb_Background = new StringBuilder();
        StringBuilder sb_TimingBar = new StringBuilder();
        StringBuilder sb_Animation = new StringBuilder();
        StringBuilder sb_UI = new StringBuilder();

        /// <summary>
        /// 실제 이미지를 로드해오는 메서드
        /// </summary>
        /// <returns></returns>
        string LoadImage()
        {
            return "";
        }

        public void Render((int row, int col) pivot)
        {

        }
    }

    public class RenderingData
    {
        public RenderLayer RenderType { get; set; }
        public Vector2 RenderingPivot { get; set; }
        public Vector2 RenderingPosition { get; set; }

        public RenderingData(
            string imageName, RenderLayer _RenderType, 
            int RenderingPivot_Row = 0, int RenderingPivot_Col = 0, 
            int RenderingPosition_Row = 0, int RenderingPosition_Col = 0
            )
        {
            // 여기에 imageName으로 이미지 로드

            RenderingPivot = new Vector2(RenderingPivot_Row, RenderingPivot_Col);
            RenderingPosition = new Vector2(RenderingPosition_Row, RenderingPosition_Col);
            RenderType = _RenderType;
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
        Animation, // 타이밍 바 
        UI
    }
}
