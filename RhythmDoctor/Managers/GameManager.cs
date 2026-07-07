using RhythmDoctor.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Managers
{
    public class GameManager
    {
        #region 싱글톤 패턴 적용 및 생성자
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

        private GameManager()
        {
            // 게임 오버 프로퍼티는 true로 시작함.
            // IsGameOver는 게임이 실행하는 동안에만 false로 설정
            IsGameOver = true;
        }
        #endregion

        public bool IsGameOver { get; set; }

        public void StartGame()
        {
            IsGameOver = false;
        }
    }
}
