using RhythmDoctor.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Core.BeatEvents
{
    // ActiveHitBeat는 해당 박자에 플레이어 인풋이 들어와야함을 설정함
    // 따라서 RhythmCore의 HitBeat를 true로 전환
    public class ActiveHitBeat : BeatEvent
    {
        int start_R = 0;
        int start_C = 0;

        public override void Play()
        {
            // 히트 타이밍을 켜준다
            CameraManager.Instance.UpdateRenderingLayer(RenderLayer.HitTiming, "HitTiming", start_R, start_C);
            CameraManager.Instance.ActiveRendering(RenderLayer.HitTiming, true);
            CameraManager.Instance.RenderScreen();

            RhythmCore.Instance.HitBeat = true;
        }

        public ActiveHitBeat(int _start_R = 8, int _start_C = 45)
        {
            start_R = _start_R;
            start_C = _start_C;
        }
    }
}