using RhythmDoctor.Core.BeatEvents;
using RhythmDoctor.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Core.Scenes
{
    public class Maingame : Scene
    {
        public override void StartScene()
        {
            base.StartScene();

            StartGame();
        }

        void StartGame()
        {
            string musicName = "Dreams Dont Stop";
            CameraManager.Instance.ActiveRendering(RenderLayer.Background, false);
            ParseEventDatas(musicName);

            RhythmCore.Instance.SetRhythm(94);
            SoundManager.Instance.Play(musicName);
            string selectedMusic = GameManager.Instance.SelectedMusic;

            for (int i = 0; i < eventDatas.Count; i++)
            {
                Action[] beatEvents = GetParsedBeatEvents(i);
                RhythmCore.Instance.PlayOneMeasure(beatEvents);
            }
        }

        BeatEventParser beattEventParser = new();
        // eventDatas[마디][박자][이벤트]
        List<List<BeatEvent>[]> eventDatas = new List<List<BeatEvent>[]>();

        void ParseEventDatas(string musicName)
        {
            // 리스트 라인 하나 -> 16박자 안에 들어갈 이벤트들
            // 각 박자마다 여러개의 이벤트들을 가지게 할거임.
            eventDatas.Clear();

            string fileName = Path.GetFileNameWithoutExtension(musicName) + ".csv";
            string projectMusicDataPath = Path.Combine(Directory.GetCurrentDirectory(), "MusicData", fileName);
            string outputMusicDataPath = Path.Combine(AppContext.BaseDirectory, "MusicData", fileName);
            string musicDataPath = File.Exists(projectMusicDataPath) ? projectMusicDataPath : outputMusicDataPath;

            string[] lines = File.ReadAllLines(musicDataPath, Encoding.UTF8);

            for (int row = 1; row < lines.Length; row++)
            {
                List<BeatEvent>[] currentLine = new List<BeatEvent>[16];
                eventDatas.Add(currentLine);

                for (int col = 0; col < currentLine.Length; col++)
                {
                    currentLine[col] = new List<BeatEvent>();
                }

                string[] eventCells = lines[row].Split(',');

                for (int col = 0; col < eventCells.Length && col < 16; col++)
                {
                    string[] eventTexts = eventCells[col].Split('/');

                    for (int i = 0; i < eventTexts.Length; i++)
                    {
                        string eventText = eventTexts[i];

                        if (string.IsNullOrWhiteSpace(eventText))
                            continue;

                        BeatEvent beatEvent = beattEventParser.ParseBeatEvent(eventText);

                        if (beatEvent != null)
                            currentLine[col].Add(beatEvent);
                    }
                }
            }
        }

        Action[] GetParsedBeatEvents(int parsingLine)
        {
            Action[] beatEvents = new Action[16];

            if (parsingLine >= eventDatas.Count)
                return beatEvents;

            List<BeatEvent>[] selectedLine = eventDatas[parsingLine];

            for (int beat = 0; beat < beatEvents.Length; beat++)
            {
                if (selectedLine[beat] == null)
                    continue;

                for (int i = 0; i < selectedLine[beat].Count; i++)
                {
                    beatEvents[beat] += selectedLine[beat][i].Play;
                }
            }

            return beatEvents;
        }
    }
}
