using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Managers
{
    public class InputManager
    {
        #region 싱글톤 패턴 적용
        private static InputManager instance;

        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputManager();
                }

                return instance;
            }
        }
        #endregion

        // 플레이어의 
        public void Listen()
        {
            GameManager gm = GameManager.Instance;

            while (!gm.IsGameOver) // 게임 오버가 되기 전까지 실행
            {
                // 키 입력이 없는데 Console.ReadKey를 바로 실행하면 프로그램이 키 입력을 기다리며 멈춰버림
                if (Console.KeyAvailable) // 현재 콘솔에 읽을 수 있는 키 입력이 있는지 확인
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true); // 입력된 키 정보를 읽고, 화면에는 표시하지 않음

                    if (keyInfo.Key == ConsoleKey.Spacebar || keyInfo.Key == ConsoleKey.B) // 입력된 키가 스페이스바인지 확인
                    {
                        HasInput = true; // 스페이스바 입력이 들어왔음을 표시
                    }
                }
            }
        }

        public bool HasInput { get; set; } // 유저의 인풋이 들어왔는지 여부를 나타내는 bool 프로퍼티
    }
}
