namespace SubatomicParticles.UnitTests.Utilities
{
    using System.Timers;

    public class TimerUtility
    {
        public static void FireTimerAndWait(Timer timer)
        {
            timer.Stop();
            timer.Interval = 1;
            timer.Start();

            // Wait for much longer than the time of the timer to allow the event time to finish.
            System.Threading.Thread.Sleep(500);
        }
    }
}
