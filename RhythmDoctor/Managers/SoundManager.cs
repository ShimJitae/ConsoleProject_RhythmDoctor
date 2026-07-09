using System;
using System.Collections.Generic;
using System.Media;
using System.Numerics;
using System.Text;

namespace RhythmDoctor.Managers
{
    public class SoundManager
    {
        string path = Path.Combine(AppContext.BaseDirectory, "Sounds");
        SoundPlayer bgmPlayer;

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
            bgmName += ".wav";

            string bgmPath = Path.Combine(path, bgmName);

            if (!File.Exists(bgmPath))
            {
                Console.WriteLine($"음원 파일을 찾을 수 없습니다: {bgmPath}");
                return;
            }

            bgmPlayer?.Stop();
            bgmPlayer?.Dispose();

            bgmPlayer = new SoundPlayer(bgmPath);
            bgmPlayer.Play();
        }

        public void PlayOneShot()
        {

        }
    }
}
