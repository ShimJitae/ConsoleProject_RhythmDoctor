using RhythmDoctor.Core.BeatEvents;
using RhythmDoctor.Managers;
using System.Threading;

GameManager gameManager = GameManager.Instance;

CameraManager.Instance.ResizeGameWindow(640, 360);
CameraManager.Instance.MoveGameWindowToCenter();

Console.WriteLine("HelloWorld");

Thread.Sleep(1000);

Console.WriteLine("ByeWorld");

char test_Off = '□', test_on = '■';
void Test()
{
    BeatEvent[] testEvents = new BeatEvent[16] { null, null, null, null, null, null, new ActiveHitBeat(), null, null, null, null, null, null, null, new ActiveHitBeat(), null };
}

gameManager.OnGameStart += Test;

//gameManager.StartGame();