namespace Glitcher
{
    /// <summary>
    /// Provides functionality to randomly launch pre-defined system programs.
    /// </summary>
    internal class ProgramLauncher
    {
        private static readonly Random _random = new();
        private static readonly string[] _programs = ["calc", "mspaint", "taskmgr"];

        /// <summary>
        /// Launches a random program from the predefined list.
        /// </summary>
        public static void Launch()
        {
            try
            {
                int programIndex = _random.Next(_programs.Length);
                string programToLaunch = _programs[programIndex];

                ProcessRunner.Start($"{programToLaunch}.exe");
            }
            catch
            {
                return;
            }
        }
    }
}
