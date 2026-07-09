using RhythmDoctor.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Core.BeatEvents
{
    public class PlaySFX : BeatEvent
    {
        string sfxName;

        public override void Play()
        {
            SoundManager.Instance.PlayOneShot(sfxName);
        }

        public PlaySFX(string _sfxName)
        {
            sfxName = _sfxName;
        }
    }
}