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
    }
}
