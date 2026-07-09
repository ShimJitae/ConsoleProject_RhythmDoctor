using RhythmDoctor.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Core.Scenes
{
    public class Scene
    {
        public virtual void StartScene()
        {
            Console.Clear();

            CameraManager.Instance.ResizeGameWindow(640, 360);
            CameraManager.Instance.MoveGameWindowToCenter();

            Console.CursorVisible = false;
        }
    }
}
