using System.Runtime.InteropServices;
using System.Text;

namespace Glitcher
{
    /// <summary>
    /// A class to manage window states, including flashing random windows by minimizing and restoring them.
    /// </summary>
    internal class WindowStateManager
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private const int SW_MINIMIZE = 6;
        private const int SW_RESTORE = 9;

        private static readonly (int width, int height) screenResolution = Screen.GetResolution();
        private static readonly Random _random = new();

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        /// <summary>
        /// Flashes a random open window by minimizing and restoring it.
        /// </summary>
        public static async Task FlashRandomAsync()
        {
            var random = new Random();
            var openWindows = GetVisibleWindows();

            var index = random.Next(openWindows.Count);
            IntPtr hWnd = FindWindow(null, openWindows[index]);

            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, SW_MINIMIZE);
                await Task.Delay(2000);
                ShowWindow(hWnd, SW_RESTORE);
            }         
        }

        public static void ManipulateRandom()
        {
            var openWindows = GetVisibleWindows();

            if (openWindows.Count > 0)
            {
                var index = _random.Next(openWindows.Count);
                IntPtr hWnd = FindWindow(null, openWindows[index]);
                if (hWnd != IntPtr.Zero && GetWindowRect(hWnd, out _))
                {
                    int newWidth = _random.Next(200, screenResolution.width);
                    int newHeight = _random.Next(200, screenResolution.height);
                    int newX = _random.Next(0, screenResolution.width);
                    int newY = _random.Next(0, screenResolution.height);

                    MoveWindow(hWnd, newX, newY, newWidth, newHeight, true);
                }
            }
        }

        private static List<string> GetVisibleWindows()
        {
            List<string> windowList = [];

            _ = EnumWindows((hWnd, lParam) =>
            {
                if (IsWindowVisible(hWnd))
                {
                    int length = GetWindowTextLength(hWnd);
                    if (length > 0)
                    {
                        StringBuilder windowText = new(length + 1);
                        _ = GetWindowText(hWnd, windowText, windowText.Capacity);
                        windowList.Add(windowText.ToString());
                    }
                }
                return true;
            }, IntPtr.Zero);

            return windowList;
        }
    }
}
