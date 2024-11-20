using System.Media;

namespace Glitcher
{
    /// <summary>
    /// Provides functionality to play random system sounds.
    /// </summary>
    internal class SystemSoundPlayer
    {
        private static readonly Random _random = new();
        private static readonly SystemSound[] _sounds = [
            SystemSounds.Beep,
            SystemSounds.Asterisk,
            SystemSounds.Exclamation,
            SystemSounds.Hand,
            SystemSounds.Question
        ];

        /// <summary>
        /// Plays a random system sound.
        /// </summary>
        public static void PlayRandom()
        {
            int soundIndex = _random.Next(_sounds.Length);
            _sounds[soundIndex].Play();
        }
    }
}
