using System;
using System.Runtime.InteropServices;
using RhythmDoctor.Core;

namespace RhythmDoctor.Managers
{
    public class CameraManager
    {
        #region 싱글톤 패턴 적용 및 생성자
        private static CameraManager instance;

        public static CameraManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CameraManager();
                }

                return instance;
            }
        }

        // GetSystemMetrics API 임포트
        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex); // Windows 운영체제에서 화면 크기 같은 시스템 정보를 가져오는 함수
        private CameraManager()
        {
            screenWidth = GetSystemMetrics(0);
            screenHeight = GetSystemMetrics(1);
        }
        #endregion

        ScreenRenderer sr = new();

        // 실제 모니터의 가로/세로 길이
        private int screenWidth;
        private int screenHeight;
        #region ResizeWindow
        public void ResizeGameWindow(int width, int height)
        {
            ResizeFocusedWindow(width, height);
        }

        private void ResizeFocusedWindow(int width, int height)
        {
            windowWidth = width; // 현재 윈도우 창 크기의 가로길이 캐싱
            windowHeight = height; // 현재 윈도우 창 크기의 세로길이 캐싱

            IntPtr windowHandle = GetForegroundWindow();

            if (windowHandle == IntPtr.Zero)
                return;

            SetWindowPos(
                windowHandle,
                IntPtr.Zero,
                100,
                100,
                width,
                height,
                SWP_NOZORDER
            );
        }
        #endregion

        int windowWidth; // 현재 띄워진 윈도우 창의 가로 길이
        int windowHeight; // 현재 띄워진 윈도우 창의 세로 길이
        #region MoveWindow
        public void MoveGameWindow(int x, int y)
        {
            MoveFocusedWindow(x, y);
        }

        private void MoveFocusedWindow(int x, int y)
        {
            IntPtr windowHandle = GetForegroundWindow();

            if (windowHandle == IntPtr.Zero)
                return;

            SetWindowPos(
                windowHandle,
                IntPtr.Zero,
                x,
                y,
                0,
                0,
                SWP_NOZORDER | SWP_NOSIZE
            );
        }
        public void MoveGameWindowToCenter()
        {
            int x = (screenWidth - windowWidth) / 2;
            int y = (screenHeight - windowHeight) / 2;

            MoveGameWindow(x, y);
        }
        #endregion

        #region 설정 정보?
        private const uint SWP_NOZORDER = 0x0004;
        private const uint SWP_NOSIZE = 0x0001;

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int x,
            int y,
            int cx,
            int cy,
            uint uFlags
        );
        #endregion

        public (int height, int width) GetWindowSize()
        {
            return (windowHeight, windowWidth);
        }

        public void UpdateRenderingLayer(RenderLayer rl, string imageName, int startP_R, int startP_C)
        {
            sr.UpdateRD(rl, imageName, startP_R, startP_C);
        }

        public void UpdateRenderingLayer(RenderLayer rl, string imageName, int startP_R, int startP_C, ConsoleColor textColor)
        {
            sr.UpdateRD(rl, imageName, startP_R, startP_C, textColor);
        }

        public void ActiveRendering(RenderLayer target, bool enabled)
        {
            sr.ActiveRendering(target, enabled);
        }

        public void RenderScreen()
        {
            sr.Render();
        }
    }
}
