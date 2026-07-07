using RhythmDoctor.Core;
using RhythmDoctor.Core.BeatEvents;
using RhythmDoctor.Managers;
using System.Threading;

CameraManager.Instance.ResizeGameWindow(640, 360);
CameraManager.Instance.MoveGameWindowToCenter();

Console.WriteLine("██████╗ ██╗  ██╗██╗   ██╗████████╗██╗  ██╗███╗   ███╗   ");
Console.WriteLine("██╔══██╗██║  ██║╚██╗ ██╔╝╚══██╔══╝██║  ██║████╗ ████║     ");
Console.WriteLine("██████╔╝███████║ ╚████╔╝    ██║   ███████║██╔████╔██║      ");
Console.WriteLine("██╔══██╗██╔══██║  ╚██╔╝     ██║   ██╔══██║██║╚██╔╝██║     ");
Console.WriteLine("██║  ██║██║  ██║   ██║      ██║   ██║  ██║██║ ╚═╝ ██║        ");
Console.WriteLine("╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝      ╚═╝   ╚═╝  ╚═╝╚═╝     ╚═╝       ");
Console.WriteLine("         ██████╗  ██████╗  ██████╗████████╗ ██████╗ ██████╗ ");
Console.WriteLine("         ██╔══██╗██╔═══██╗██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗");
Console.WriteLine("         ██║  ██║██║   ██║██║        ██║   ██║   ██║██████╔╝");
Console.WriteLine("         ██║  ██║██║   ██║██║        ██║   ██║   ██║██╔══██╗");
Console.WriteLine("         ██████╔╝╚██████╔╝╚██████╗   ██║   ╚██████╔╝██║  ██║");
Console.WriteLine("         ╚═════╝  ╚═════╝  ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝");














//TestClass.Test();

public static class TestClass
{
    static BeatEvent[] testEvents = new BeatEvent[16]
    {
        null, null, new ActiveHitBeat(), null,
        null, null, new ActiveHitBeat(), null,
        null, null, new ActiveHitBeat(), null,
        null, null, new ActiveHitBeat(), null
    };

    static string testStr = "□ □ ■ □ □ □ ■ □ □ □ ■ □ □ □ ■ □";
    static int beatIndex = 0;
    static int arrowLine = -1;
    static int successLine = -1;
    static int failLine = -1;
    static int logLine = -1;
    public static void Test()
    {
        Thread.Sleep(1000);
        GameManager.Instance.StartGame();

        RhythmCore.Instance.SetRhythm(94);

        for (int i = 0; i < 15; i++)
        {
            beatIndex = 0;
            Console.Clear();
            Console.WriteLine(testStr);
            arrowLine = Console.CursorTop;
            Console.WriteLine();
            successLine = Console.CursorTop;
            Console.WriteLine();
            failLine = Console.CursorTop;
            Console.WriteLine();
            logLine = Console.CursorTop;
            Console.WriteLine();
            PrintCount();

            RhythmCore.Instance.PlayOneMeasure(testEvents);

            HideArrow();
            ClearLine(logLine);
        }
    }

    static int suc = 0, fail = 0;
    public static void NextBeat()
    {
        if (beatIndex >= 16)
            return;

        if (arrowLine < 0)
        {
            Console.WriteLine(testStr);
            arrowLine = Console.CursorTop;
            Console.WriteLine();
        }

        Console.SetCursorPosition(0, arrowLine);
        Console.Write(new string(' ', testStr.Length));
        Console.SetCursorPosition(beatIndex * 2, arrowLine);
        Console.Write("↑");
        Console.SetCursorPosition(0, logLine);

        beatIndex++;
    }

    public static void Count(bool _suc)
    {
        if (_suc)
            suc++;
        else
            fail++;

        PrintCount();
        Console.SetCursorPosition(0, logLine);
    }

    static void HideArrow()
    {
        if (arrowLine < 0)
            return;

        Console.SetCursorPosition(0, arrowLine);
        Console.Write(new string(' ', testStr.Length));
        Console.SetCursorPosition(0, logLine);
    }

    static void PrintCount()
    {
        Console.SetCursorPosition(0, successLine);
        Console.Write($"성공: {suc}   ");
        Console.SetCursorPosition(0, failLine);
        Console.Write($"실패: {fail}   ");
    }

    static void ClearLine(int line)
    {
        if (line < 0)
            return;

        Console.SetCursorPosition(0, line);
        Console.Write(new string(' ', Console.WindowWidth - 1));
        Console.SetCursorPosition(0, line);
    }
}

