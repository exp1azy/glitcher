namespace Glitcher
{
    /// <summary>
    /// A class for creating fake shortcuts on the desktop.
    /// </summary>
    internal class ShortcutFactory
    {
        private int _index;

        /// <summary>
        /// Method to create a fake shortcut on the desktop.
        /// </summary>
        /// <param name="prefix">The prefix for the shortcut name.</param>
        public void CreateShortcut(string prefix)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fakeShortcutPath = Path.Combine(desktopPath, $"{prefix}{++_index}.lnk");
            File.Create(fakeShortcutPath).Close();
        }
    }
}
