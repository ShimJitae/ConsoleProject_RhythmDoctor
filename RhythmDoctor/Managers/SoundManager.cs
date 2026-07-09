using System;
using System.Collections.Generic;
using System.Text;
using NAudio.Wave;

namespace RhythmDoctor.Managers
{
    public class SoundManager
    {
        string path = Path.Combine(AppContext.BaseDirectory, "Sounds");
        WaveOutEvent? bgmOutput;
        AudioFileReader? bgmReader;
        string extension = ".mp3";

        #region 싱글톤 패턴 적용 및 생성자
        private static SoundManager instance;

        public static SoundManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SoundManager();
                }

                return instance;
            }
        }

        public SoundManager()
        {
        }
        #endregion

        public void Play(string bgmName)
        {
            bgmOutput?.Stop();
            bgmOutput?.Dispose();
            bgmReader?.Dispose();

            string bgmPath = GetSoundPath(bgmName);

            if (string.IsNullOrEmpty(bgmPath))
                return;

            bgmReader = new AudioFileReader(bgmPath);
            bgmOutput = new WaveOutEvent();
            bgmOutput.Init(bgmReader);
            bgmOutput.Play();
        }


        public void StopBGM()
        {
            bgmOutput?.Stop();
            bgmOutput?.Dispose();
            bgmReader?.Dispose();
        }

        public void PlayOneShot(string sfxName)
        {
            if (string.IsNullOrEmpty(sfxName))
                return;

            string sfxPath = GetSoundPath(sfxName);

            if (string.IsNullOrEmpty(sfxPath))
                return;

            AudioFileReader sfxReader = new AudioFileReader(sfxPath);
            WaveOutEvent sfxOutput = new WaveOutEvent();

            sfxOutput.Init(sfxReader);
            sfxOutput.PlaybackStopped += (sender, args) =>
            {
                sfxOutput.Dispose();
                sfxReader.Dispose();
            };
            sfxReader.Volume = 0.5f;
            sfxOutput.Play();
        }

        string GetSoundPath(string soundName)
        {
            soundName += extension;

            string soundPath = Path.Combine(path, soundName);

            if (!File.Exists(soundPath))
            {
                Console.WriteLine($"음원 파일을 찾을 수 없습니다: {soundPath}");
                return "";
            }

            return soundPath;
        }
    }
}
