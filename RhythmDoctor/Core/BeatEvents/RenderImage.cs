using RhythmDoctor.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Core.BeatEvents
{
    internal class RenderImage : BeatEvent
    {
        RenderLayer layer;
        string imageName;
        int start_R, start_C;

        public override void Play()
        {
            CameraManager.Instance.UpdateRenderingLayer(layer, imageName, start_R, start_C);
            CameraManager.Instance.RenderScreen();
        }

        public RenderImage(RenderLayer _layer, string _imageName, int _start_R, int _start_C)
        {
            layer = _layer;
            imageName = _imageName;
            start_R = _start_R; 
            start_C = _start_C;
        }
    }
}