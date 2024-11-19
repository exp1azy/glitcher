namespace Glitcher
{
    internal class Program
    {
        private static GlitchAction[] actions;

        static async Task Main()
        {
            actions = [ 
                GlitchAction.FlashWindow, 
                GlitchAction.MoveCursor, 
                GlitchAction.PlaySound, 
                GlitchAction.ChangeVolume, 
                GlitchAction.LaunchProgram,
                GlitchAction.OpenWebPage,
                GlitchAction.OpenImage
            ];

            var random = new Random();

            TimerSetter.Set(() =>
            {
                var actionIndex = random.Next(actions.Length);
                var action = actions[actionIndex];

                switch (action)
                {
                    case GlitchAction.FlashWindow:
                        FlashWindow();
                        break;
                    case GlitchAction.MoveCursor:
                        MoveCursor();
                        break;
                    case GlitchAction.PlaySound:
                        PlaySound();
                        break;
                    case GlitchAction.ChangeVolume:
                        ChangeVolume();
                        break;
                    case GlitchAction.LaunchProgram:
                        LaunchProgram();
                        break;
                    case GlitchAction.OpenWebPage:
                        OpenWebPage();
                        break;
                    case GlitchAction.OpenImage:
                        OpenImage();
                        break;
                }
            }, 2);
            
            await Task.Delay(Timeout.Infinite);
        }

        /// <summary>
        /// Flash a random window on the screen.
        /// </summary>
        private static void FlashWindow() => WindowStateManager.FlashRandom();

        /// <summary>
        /// Play a random sound.
        /// </summary>
        private static void PlaySound() => SystemSoundsPlayer.PlayRandom();

        /// <summary>
        /// Open a web page in the default browser.
        /// </summary>
        private static void OpenWebPage() => ProcessRunner.Start("https://youtu.be/CbJohjc_D2U?si=gPQ7Fb4e_kZpgB_z");

        /// <summary>
        /// Launch a random program.
        /// </summary>
        private static void LaunchProgram() => ProgramLauncher.Launch();

        /// <summary>
        /// Open a random image.
        /// </summary>
        private static void OpenImage() => ImageOpener.OpenRandom();

        /// <summary>
        /// Move the cursor to a random position on the screen.
        /// </summary>
        private static void MoveCursor()
        {
            var random = new Random();
            var (width, height) = Screen.GetResolution();
            var x = random.Next(width);
            var y = random.Next(height);
            CursorController.Move(x, y);
        }

        /// <summary>
        /// Change the system volume by a random amount.
        /// </summary>
        private static void ChangeVolume()
        {
            var random = new Random();
            var volumeChanger = new VolumeChanger();
            var value = random.Next(-50, 50);
            volumeChanger.AdjustVolume(value);
        }
    }
}
