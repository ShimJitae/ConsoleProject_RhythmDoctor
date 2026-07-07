namespace RhythmDoctor.Core.BeatEvents {
    /// <summary>
    /// 비트이벤트는 한 마디의 16개의 반의 반박자마다 실행시킬 이벤트 종류이다.
    /// 각 박자마다 전달받은 이벤트를 실행한다.
    /// 이벤트 예시(초안)
    /// 1. 신호음 주기 2. 해당 박자가 입력 타이밍인지 주기 3. 카메라 연출(창 사이즈 조절 등)
    /// 각 이벤트들은 이벤트마다 기능을 따로 구현해야하기 때문에,
    /// Play()를 추상메서드로 만들어줌
    /// </summary>
    public abstract class BeatEvent
    {
        public abstract void Play();
    }
}