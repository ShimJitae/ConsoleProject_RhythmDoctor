using RhythmDoctor.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RhythmDoctor.Core.Scenes
{
    public class Result : Scene
    {
        public override void StartScene()
        {
            base.StartScene();

            CameraManager.Instance.ActiveRendering(RenderLayer.TimingBar, false);
            CameraManager.Instance.ActiveRendering(RenderLayer.HitTiming, false);
            CameraManager.Instance.ActiveRendering(RenderLayer.UI, false);
            Console.Clear();

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed.TotalSeconds < 1) // 1초 대기
            {
                Thread.Sleep(1);
            }

            switch (RhythmCore.Instance.failCount)
            {
                case 1: CameraManager.Instance.UpdateRenderingLayer(RenderLayer.Background, "A", 0, 0); break;
                case 2: CameraManager.Instance.UpdateRenderingLayer(RenderLayer.Background, "B+", 0, 0); break;
                case 3: CameraManager.Instance.UpdateRenderingLayer(RenderLayer.Background, "B", 0, 0); break;
                case 4: CameraManager.Instance.UpdateRenderingLayer(RenderLayer.Background, "C", 0, 0); break;
                case 5: CameraManager.Instance.UpdateRenderingLayer(RenderLayer.Background, "D", 0, 0); break;
                case 6: CameraManager.Instance.UpdateRenderingLayer(RenderLayer.Background, "F", 0, 0); break;
            }

            CameraManager.Instance.ActiveRendering(RenderLayer.Background, true);
            CameraManager.Instance.RenderScreen();

            Console.ReadLine();

            SceneManager.Instance.ChangeScene(ScnenType.Title);
        }
    }
}
