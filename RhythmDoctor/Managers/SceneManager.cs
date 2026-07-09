using RhythmDoctor.Core.Scenes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Managers
{
    public class SceneManager
    {
        #region 싱글톤 패턴 적용 및 생성자
        private static SceneManager instance;

        public static SceneManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SceneManager();
                }

                return instance;
            }
        }

        private SceneManager()
        {
        }
        #endregion

        Dictionary<ScnenType, Scene> sceneDic = new Dictionary<ScnenType, Scene>()
        {
            { ScnenType.Title, new Title() },
            { ScnenType.Maingame, new Maingame() },
            { ScnenType.Result, new Result() }
        };

        public void ChangeScene(ScnenType st)
        {
            sceneDic[st].StartScene();
        }
    }

    public enum ScnenType
    {
        Title,
        Maingame,
        Result
    }
}
