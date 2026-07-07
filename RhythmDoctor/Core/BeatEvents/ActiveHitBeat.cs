using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Core.BeatEvents
{
    // ActiveHitBeat는 해당 박자에 플레이어 인풋이 들어와야함을 설정함
    // 따라서 RhythmCore의 HitBeat를 true로 전환
    public class ActiveHitBeat : BeatEvent
    {
        public override void Play()
        {
            RhythmCore.Instance.HitBeat = true;
        }
    }
}
