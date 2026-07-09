using System;
using System.Collections.Generic;
using System.Media;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace RhythmDoctor.Managers
{
    public class SoundManager
    {
        string path = Path.Combine(AppContext.BaseDirectory, "Sounds");
        SoundPlayer bgmPlayer;
        string extension = ".wav";

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
            bgmPlayer?.Stop();
            bgmPlayer?.Dispose();

            bgmPlayer = new SoundPlayer(GetSoundPath(bgmName));
            bgmPlayer.Play();
        }

        public void PlayOneShot(string sfxName)
        {
            SoundPlayer sfxPlayer = new SoundPlayer(GetSoundPath(sfxName));
            sfxPlayer.Play();
        }

        string GetSoundPath(string soundName)
        {
            soundName += ".wav";

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
