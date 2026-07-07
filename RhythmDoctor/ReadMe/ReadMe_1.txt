1차 정리본

현재 구상한 시스템 구조

1. 게임 시작 세팅
GameManager의 IsGameOver를 false 로 전환.
RhythmCore의 SetRhythm() 실행하며 세팅
InputManager의 Listen() 실행하며 인풋을 받도록 전환

2. 게임 시작
음악 재생
RhythmCore의 PlayOneMeasure를 음악이 실행되거나 게임이 종료될 때까지 반복하여 실행

3. 게임 진행 방식
게임이 시작되면 InputManager에서 Listen을 실행한다.
-> Listen하는 동안 플레이어의 인풋을 감지한다. (스페이스바, 테스트 기간 동안에는 B도 받도록 해놓음)

RhythmCore에서 반의 반박자 16개를 한 마디마다 실행한다.
매 마디가 실행될 때마다 크기가 16인 BeatEvent 배열을 받고,
박자마다 실행되는 이벤트들을 실행한다.
해당 박자가 시작될 때, RhythmCore의 HitBeat가 활성화되었을때, Player의 인풋이 들어왔냐/안들어왔냐로 박자 성공/실패 를 나눔