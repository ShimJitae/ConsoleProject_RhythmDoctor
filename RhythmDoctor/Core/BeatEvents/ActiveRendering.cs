using RhythmDoctor.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Core.BeatEvents
{
    public class ActiveRendering : BeatEvent
    {
        RenderLayer target;
        bool enabled;

        public override void Play()
        {
            CameraManager.Instance.ActiveRendering(target, enabled);
        }

        public ActiveRendering(RenderLayer _target, bool _enabled)
        {
            target = _target;
            enabled = _enabled;
        }
    }
}
