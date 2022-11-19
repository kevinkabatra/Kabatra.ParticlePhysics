namespace SubatomicParticles.UnitTests.Utilities
{
    using System.Timers;

    /// <summary>
    ///     Utility for getting a timer to fire immediately and then waiting a predetermined amount.
    /// <para>Note: Once the timer goes off the logic that is triggered will tke n-amount of time. Currently I have
    /// set this utility to wait for a full second but this might need to be a parameter if future timers take a
    /// longer amount of time to complete.</para>
    /// <para>Additionally, as you add logic to the event that is triggered by the timer that will increase the
    /// n-time that it takes for the event to complete. Essentially testing any code with a timer is a race condition,
    /// where you must make sure that you are in last place.</para>
    /// </summary>
    public class TimerUtility
    {
        public static void FireTimerAndWait(Timer timer)
        {
            try 
            {
                timer.Stop();
                timer.Interval = 1;
                timer.Start();
            }
            catch(System.ObjectDisposedException) 
            {
                // Timer has already been completed.
                return;
            }

            // Wait for much longer than the time of the timer to allow the event time to finish.
            System.Threading.Thread.Sleep(10);
        }
    }
}
