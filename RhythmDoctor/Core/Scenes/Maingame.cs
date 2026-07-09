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
        new RenderImage(RenderLayer.TimingBar, "TimingBar_2", 8, 3), new RenderImage(RenderLayer.TimingBar, "TimingBar_3", 8, 3), null, new RenderImage(RenderLayer.TimingBar, "TimingBar_1", 8, 3),
        new RenderImage(RenderLayer.TimingBar, "TimingBar_2", 8, 3), new RenderImage(RenderLayer.TimingBar, "TimingBar_3", 8, 3), null, new RenderImage(RenderLayer.TimingBar, "TimingBar_1", 8, 3),
        new RenderImage(RenderLayer.TimingBar, "TimingBar_2", 8, 3), new RenderImage(RenderLayer.TimingBar, "TimingBar_3", 8, 3), null, new RenderImage(RenderLayer.TimingBar, "TimingBar_1", 8, 3),
        new RenderImage(RenderLayer.TimingBar, "TimingBar_2", 8, 3), new RenderImage(RenderLayer.TimingBar, "TimingBar_3", 8, 3), null, new RenderImage(RenderLayer.TimingBar, "TimingBar_1", 8, 3)
    };

        void StartGame()
        {
            CameraManager.Instance.ActiveRendering(RenderLayer.Background, false);
            RhythmCore.Instance.SetRhythm(94);
            string selectedMusic = GameManager.Instance.SelectedMusic;

            for (int i = 0; i < 10; i++)
            {
                RhythmCore.Instance.PlayOneMeasure(testEvents);
            }
        }
    }
}
