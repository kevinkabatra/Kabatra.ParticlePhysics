namespace Universe.Events.BetaDecay
{
    using System.Timers;

    public class BetaDecayTimer : Timer
    {
        public BetaDecayEvent BetaDecayEvent { get; }

        public BetaDecayTimer(BetaDecayEvent betaDecayEvent, double interval) : base(interval)
        {
            BetaDecayEvent = betaDecayEvent;
        }
    }
}
