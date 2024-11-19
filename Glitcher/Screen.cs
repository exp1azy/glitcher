using System.Runtime.InteropServices;

namespace Glitcher
{
    /// <summary>
    /// Provides functionality to retrieve the screen resolution using native system calls.
    /// </summary>
    internal class Screen
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        private const int HORZRES = 8;
        private const int VERTRES = 10;

        /// <summary>
        /// Gets the current screen resolution.
        /// </summary>
        /// <returns>A tuple containing the screen width and height in pixels.</returns>
        public static (int width, int height) GetResolution()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            int width = GetDeviceCaps(hdc, HORZRES);
            int height = GetDeviceCaps(hdc, VERTRES);
            _ = ReleaseDC(IntPtr.Zero, hdc);
            return (width, height);
        }
    }
}
