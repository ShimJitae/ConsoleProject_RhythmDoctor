using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Core.BeatEvents;

namespace RhythmDoctor.Managers
{
    public class RhythmManager
    {
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
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 16; i++)
            {
                targetTime = sixteenthBeatTime * i;

                while (stopwatch.Elapsed.TotalSeconds < targetTime)
                {
                    // 반의 반박자 만큼 멈췄다 진행
                }

                Console.WriteLine($"{i + 1}번째 반의 반박자");
            }
        }
    }
}
