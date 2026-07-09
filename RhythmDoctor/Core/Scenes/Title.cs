using RhythmDoctor.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Core.Scenes
{
    public class Title : Scene
    {
        public Title()
        {
            musicList = new() { "Test" };
        }

        public override void StartScene()
        {
            base.StartScene();

            CameraManager.Instance.UpdateRenderingLayer(RenderLayer.Background, "Title", 1, 4);
            CameraManager.Instance.RenderScreen();
        }

        // 플레이할 수 있는 음악 리스트
        List<string> musicList;
        // 현재 선택한 musicList에서의 인덱스
        int selectedIndex;
        public void SelectMusic()
        {
            // 우선 음악은 1개만 만들거지만, 추후 음악을 여러개 만들 업데이트를 고려하여 이렇게 메서드 초안을 구성했음
            selectedIndex = 0;

            GameManager.Instance.SelectedMusic = musicList[selectedIndex];
        }
    }
}
