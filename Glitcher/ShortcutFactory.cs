namespace Glitcher
{
    /// <summary>
    /// A class for creating fake shortcuts on the desktop.
    /// </summary>
    internal class ShortcutFactory
    {
        private int _index;
        private readonly Random _random = new();
        private readonly string _desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        /// <summary>
        /// Method to create a fake shortcut on the desktop.
        /// </summary>
        /// <param name="prefix">The prefix for the shortcut name.</param>
        public void CreateShortcut(string prefix)
        {
            ProcessCreating(prefix);
        }

        public void CreateShortcut(params string[] prefixes)
        {
            ProcessCreating(prefixes[_random.Next(prefixes.Length)]);
        }

        private void ProcessCreating(string prefix)
        {
            string fakeShortcutPath = Path.Combine(_desktopPath, $"{prefix}{++_index}.lnk");
            File.Create(fakeShortcutPath).Close();
        }
    }
}
