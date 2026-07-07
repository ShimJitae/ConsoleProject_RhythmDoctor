using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Core.BeatEvents;

namespace RhythmDoctor.Core
{
    public class RhythmCore
    {
        #region 싱글톤 패턴 적용
        private static RhythmCore instance;

        public static RhythmCore Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RhythmCore();
                }

                return instance;
            }
        }
        #endregion

        /// <summary>
        /// 현재 플레이할 음악의 리듬 타이밍을 세팅하는 단계
        /// 게임을 시작하기 전에 이 메서드를 실행시켜서 몇 bpm인지 설정해줘야함.
        /// SetRhythm() 이후에 PlayOneMeasure()를 반복하면서 게임을 진행함
        /// </summary>
        int bpm = 0;
        double oneBeatTime = 0;
        double sixteenthBeatTime = 0;
        double targetTime = 0;
        public void SetRhythm(int _bpm = 94)
        {
            // 현재 목표는 bpm 94
            bpm = _bpm;
            oneBeatTime = 60.0 / bpm;
            sixteenthBeatTime = oneBeatTime / 4.0;
            targetTime = 0;
        }

        /// <summary>
        /// 한 마디에 반의 반박자 16개가 있음
        /// PlayOneMeasure()에서는 한 박자를 기준으로 만들어진 메서드
        /// for문에서 한 번에 반의 반박자 시간만큼 시간을 감지하고, 이를 16번 반복
        /// </summary>
        public void PlayOneMeasure(BeatEvent[] b_Events)
        {
            #region b_Events 형식 검사
            // 이벤트 배열이 null이면 return
            if (b_Events == null)
            {
                Console.WriteLine("※ RhythmManager : PlayOneMeasure에서 b_Events로 Null을 받음");
                return;
            }
            // 이벤트 배열의 크기가 형식에 맞지 않으면 return
            if (b_Events.Length != 16)
            {
                Console.WriteLine("※ RhythmManager : PlayOneMeasure에서 b_Events의 크기가 16이 아님");
                return;
            }
            #endregion

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 16; i++)
            {
                /// 박자마다 IsWithinHitWindow를 false로 전환해줌
                /// 플레이어의 인풋을 받는 타이밍을 설정하는 것은 b_Events에서 전환해줌
                IsWithinHitWindow = false;

                targetTime = sixteenthBeatTime * i;

                b_Events[i]?.Play(); // 비트이벤트가 null이 아닐 경우에만 Play
                while (stopwatch.Elapsed.TotalSeconds < targetTime) // 비트 이벤트를 실행하고 반의 반박자만큼 대기
                {
                    Thread.Sleep(1); // while문이 CPU를 계속 쓰지 않도록 현재 스레드를 잠깐 쉬게 한다 -> 최적화
                } 

                Console.WriteLine($"{i + 1}번째 반의 반박자");
            }
        }

        /// <summary>
        /// 현재 박자가 플레이어의 인풋을 받았을 때, 맞는 타이밍인지 확인하는 bool 프로퍼티
        /// IsWithinHitWindow가 true일 때, 플레이어의 인풋이 들어오면(ex 스페이스바), 맞는 타이밍에 누른거임
        /// </summary>
        public bool IsWithinHitWindow { get; set; }
    }
}
