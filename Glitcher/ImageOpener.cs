namespace Glitcher
{
    /// <summary>
    /// Provides functionality to randomly open images from a predefined set.
    /// </summary>
    internal class ImageOpener
    {
        private static readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
        private static readonly string[] _images = Directory.GetFiles(_path);
        private static readonly Random _random = new();

        /// <summary>
        /// Opens a random image from the predefined set.
        /// </summary>
        public static void OpenRandom()
        {
            if (_images.All(i => i.EndsWith(".jfif")))
            {
                var imageIndex = _random.Next(_images.Length);
                var imageToOpen = Path.GetFileName(_images[imageIndex]);

                string pathToRunProcess = Path.Combine(_path, imageToOpen);

                ProcessRunner.Start(pathToRunProcess);
            }
        }
    }
}
