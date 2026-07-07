using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Managers
{
    public class SoundManager
    {
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

        private SoundManager()
        {
        }
        #endregion
    }
}
