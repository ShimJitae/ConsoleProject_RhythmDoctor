using RhythmDoctor.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Core.BeatEvents
{
    public class SetTimingBar : BeatEvent
    {
        int start_R = 7, start_C = 3;

        int imageNum;

        public override void Play()
        {
            CameraManager.Instance.UpdateRenderingLayer(RenderLayer.TimingBar, $"TimingBar_{imageNum}", start_R, start_C);
            CameraManager.Instance.RenderScreen();
        }

        public SetTimingBar(int _imageNum)
        {
            imageNum = _imageNum;
        }
    }
}
