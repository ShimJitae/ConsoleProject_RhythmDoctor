using System;
using System.Runtime.InteropServices;

namespace RhythmDoctor.Managers
{
    public class CameraManager
    {
        #region ResizeWindow
        public void ResizeGameWindow(int width, int height)
        {
            ResizeFocusedWindow(width, height);
        }

        private void ResizeFocusedWindow(int width, int height)
        {
            Thread.Sleep(100);

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

        private const uint SWP_NOZORDER = 0x0004;

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


    }
}