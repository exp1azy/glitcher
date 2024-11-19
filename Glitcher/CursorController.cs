using System.Runtime.InteropServices;

namespace Glitcher
{
    /// <summary>
    /// Provides functionality for controlling the mouse cursor position.
    /// </summary>
    internal class CursorController
    {
        /// <summary>
        /// Sets the cursor position to the specified screen coordinates.
        /// </summary>
        /// <param name="X">The x-coordinate of the cursor's new position.</param>
        /// <param name="Y">The y-coordinate of the cursor's new position.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        /// <summary>
        /// Moves the mouse cursor to the specified screen coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate of the target position.</param>
        /// <param name="y">The y-coordinate of the target position.</param>
        public static void Move(int x, int y)
        {
            SetCursorPos(x, y);
        }
    }
}
