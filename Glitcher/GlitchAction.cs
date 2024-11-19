namespace Glitcher
{
    /// <summary>
    /// Enumeration of actions to simulate various glitches or effects.
    /// </summary>
    public enum GlitchAction
    {
        /// <summary>
        /// Flashes the window to grab the user's attention.
        /// </summary>
        FlashWindow,

        /// <summary>
        /// Moves the mouse cursor to a random or predefined position.
        /// </summary>
        MoveCursor,

        /// <summary>
        /// Plays a sound file or system sound.
        /// </summary>
        PlaySound,

        /// <summary>
        /// Changes the system's audio volume level.
        /// </summary>
        ChangeVolume,

        /// <summary>
        /// Launches an external program or executable.
        /// </summary>
        LaunchProgram,

        /// <summary>
        /// Opens a specified webpage in the default web browser.
        /// </summary>
        OpenWebPage,

        /// <summary>
        /// Opens an image file, displaying it in the default image viewer.
        /// </summary>
        OpenImage
    }
}
