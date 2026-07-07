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

                    #region InitializeManagersInOrder
                    // GameManager는 프로그램이 실행될 때, 반드시 제일 먼저 실행되도록
                    // 여기에 싱글톤들이 호출되어야 하는 순서에 맞게 싱글톤들의 인스턴스를 만들어줌
                    InputManager inputManager = InputManager.Instance;
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

            musicList = new();

            // 게임이 시작할 때, IsGameOver = false가 되는 로직을 구독
            OnGameStart += () => IsGameOver = false;
        }
        #endregion

        public bool IsGameOver { get; set; }

        // 플레이할 수 있는 음악 리스트
        List<string> musicList;
        // 현재 선택한 musicList에서의 인덱스
        int selectedIndex;
        public void SelectMusic()
        {
            // 우선 음악은 1개만 만들거지만, 추후 음악을 여러개 만들 업데이트를 고려하여 이렇게 메서드 초안을 구성했음
            selectedIndex = 0;
        }

        public event Action OnGameStart;
        public string SelectedMusic { get; set; }
        public void StartGame()
        {
            SelectedMusic = musicList[selectedIndex];

            // StartGame을 할 때, 구독되어있던 게임 시작 로직들 모두 실행
            OnGameStart?.Invoke();
        }
    }
}
