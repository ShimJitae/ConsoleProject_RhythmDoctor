using RhythmDoctor.Core;
using RhythmDoctor.Core.BeatEvents;
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

                    #region InitializeManagersInOrder
                    // GameManager는 프로그램이 실행될 때, 반드시 제일 먼저 실행되도록
                    // 여기에 싱글톤들이 호출되어야 하는 순서에 맞게 싱글톤들의 인스턴스를 만들어줌
                    InputManager inputManager = InputManager.Instance;

                    CameraManager cameraManager = CameraManager.Instance;
                    SoundManager soundManager = SoundManager.Instance;
                    #endregion
                }

                return instance;
            }
        }

        private GameManager()
        {
            // 게임 오버 프로퍼티는 true로 시작함.
            // IsGameOver는 게임이 실행하는 동안에만 false로 설정
            IsGameOver = true;

            // 게임이 시작할 때, IsGameOver = false가 되는 로직을 구독
            OnGameStart += () => IsGameOver = false;
        }
        #endregion

        public bool IsGameOver { get; set; }

        public event Action OnGameStart;
        public string SelectedMusic { get; set; }
        public void StartGame()
        {
            // StartGame을 할 때, 구독되어있던 게임 시작 로직들 모두 실행
            OnGameStart?.Invoke();
        }
    }
}
