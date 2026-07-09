using RhythmDoctor.Core.BeatEvents;
using RhythmDoctor.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Core.Scenes
{
    public class Maingame : Scene
    {
        public override void StartScene()
        {
            base.StartScene();

            StartGame();
        }

        BeatEvent[] testEvents = new BeatEvent[16]
    {
        new SetTimingBar(2), new SetTimingBar(3), new SetTimingBar(1), null,
        new SetTimingBar(2), new SetTimingBar(3), new SetTimingBar(1), null,
        new SetTimingBar(2), new SetTimingBar(3), new SetTimingBar(1), null,
        new SetTimingBar(2), new SetTimingBar(3), new SetTimingBar(1), null
    };

        void StartGame()
        {
            CameraManager.Instance.ActiveRendering(RenderLayer.Background, false);
            SoundManager.Instance.Play("Dreams Dont Stop");
            RhythmCore.Instance.SetRhythm(94);
            string selectedMusic = GameManager.Instance.SelectedMusic;

            for (int i = 0; i < 10; i++)
            {
                RhythmCore.Instance.PlayOneMeasure(testEvents);
            }
        }
    }
}
