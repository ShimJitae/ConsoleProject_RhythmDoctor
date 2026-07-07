1차 정리본

현재 구상한 시스템 구조

1. 게임 시작 세팅
GameManager의 IsGameOver를 false 로 전환.
RhythmCore의 SetRhythm() 실행하며 세팅
InputManager의 Listen() 실행하며 인풋을 받도록 전환

2. 게임 시작
음악 재생
RhythmCore의 PlayOneMeasure를 음악이 실행되거나 게임이 종료될 때까지 반복하여 실행