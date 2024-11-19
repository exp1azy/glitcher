namespace Glitcher
{
    /// <summary>
    /// A class for setting up a timer that executes a given action at specified time intervals.
    /// </summary>
    internal class TimerSetter
    {
        /// <summary>
        /// Sets a timer to execute a given action every specified interval.
        /// </summary>
        /// <param name="action">The action to be executed.</param>
        /// <param name="seconds">The interval in seconds at which the action should be executed.</param>
        public static void Set(Action action, int seconds)
        {
            var timer = new System.Timers.Timer();
            timer.Elapsed += (s, e) =>
            {
                action();
                timer.Interval = TimeSpan.FromSeconds(seconds).TotalMilliseconds;
                timer.Start();
            };
            timer.AutoReset = true;
            timer.Start();
        }
    }
}
