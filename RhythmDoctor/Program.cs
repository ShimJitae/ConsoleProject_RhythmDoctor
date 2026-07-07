using RhythmDoctor.Managers;
using System.Threading;

GameManager gameManager = GameManager.Instance;

CameraManager.Instance.ResizeGameWindow(640, 360);
CameraManager.Instance.MoveGameWindowToCenter();

Console.WriteLine("HelloWorld");

Thread.Sleep(1000);

Console.WriteLine("ByeWorld");

//gameManager.StartGame();