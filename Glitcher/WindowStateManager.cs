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
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_MINIMIZE = 6;
        private const int SW_RESTORE = 9;

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        /// <summary>
        /// Flashes a random open window by minimizing and restoring it.
        /// </summary>
        public static void FlashRandom()
        {
            var random = new Random();
            var openWindows = GetOpenWindows();

            var index = random.Next(openWindows.Count - 1);
            IntPtr hWnd = FindWindow(null, openWindows[index]);

            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, SW_MINIMIZE);
                Task.Delay(2000).Wait();
                ShowWindow(hWnd, SW_RESTORE);
            }         
        }

        private static List<string> GetOpenWindows()
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
