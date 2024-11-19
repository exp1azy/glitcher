using System.Media;

namespace Glitcher
{
    /// <summary>
    /// Provides functionality to play random system sounds.
    /// </summary>
    internal class SystemSoundsPlayer
    {
        /// <summary>
        /// Plays a random system sound.
        /// </summary>
        public static void PlayRandom()
        {
            var random = new Random();
            var sounds = new SystemSound[]
            {
                SystemSounds.Beep,
                SystemSounds.Asterisk,
                SystemSounds.Exclamation,
                SystemSounds.Hand,
                SystemSounds.Question
            };

            int soundIndex = random.Next(sounds.Length);
            sounds[soundIndex].Play();
        }
    }
}
