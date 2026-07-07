using RhythmDoctor.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Managers
{
    public class GameManager
    {
        #region 싱글톤 패턴 적용
        private static GameManager instance;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }

                return instance;
            }
        }
        #endregion

        public bool IsGameOver { get; set; }
    }
}
