using RhythmDoctor.Core;
using RhythmDoctor.Core.BeatEvents;
using RhythmDoctor.Managers;
using System.Threading;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

GameManager gm = GameManager.Instance;

SceneManager.Instance.ChangeScene(ScnenType.Title);