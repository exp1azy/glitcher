namespace Glitcher
{
    /// <summary>
    /// Provides functionality to randomly open images from a predefined set.
    /// </summary>
    internal class ImageOpener
    {
        private static readonly string[] images = [ "amogus", "botinok", "popich", "russia" ];

        /// <summary>
        /// Opens a random image from the predefined set.
        /// </summary>
        public static void OpenRandom()
        {
            var random = new Random();
            var imageIndex = random.Next(images.Length);
            var imageToOpen = images[imageIndex];

            string relativePath = Path.Combine("Images", $"{imageToOpen}.jfif");
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            ProcessRunner.Start(absolutePath);
        }
    }
}
