using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Core.Scenes
{
    public enum ScnenType
    {
        Title,
        Maingame,
        Result
    }

    public abstract class Scene
    {
        public abstract void StartScene();
    }
}
