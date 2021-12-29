namespace SubatomicParticles.DataModels
{
    using System;
    using System.Timers;
    using Constants;

    /// <summary>
    ///     The neutron is a subatomic particle which has a neutral charge and a mass slightly greater than that of a Proton.
    /// <para>See the following article for more information:</para>
    /// <para>1. <a href="https://en.wikipedia.org/wiki/Neutron">Wikipedia: Neutron</a></para>
    /// </summary>
    public class Neutron : CompositeParticle
    {
        public const ChargeType ConstantChargeType = ChargeType.Neutral;
        public static readonly double ConstantMass = 1.67492749804 * Math.Pow(10, -27);
        //public static readonly int ConstantBetaDecayTimeInSeconds = 879;
        public static readonly int ConstantBetaDecayTimeInSeconds = 5;
        public static readonly int ConstantBetaDecayTimeInMilliseconds = ConstantBetaDecayTimeInSeconds * 1000;

        public Neutron() : base(ConstantChargeType, ConstantMass)
        {
            var betaDecayEvent = new Timer(ConstantBetaDecayTimeInMilliseconds);
            betaDecayEvent.Elapsed += BetaDecay;
            betaDecayEvent.AutoReset = false;
            betaDecayEvent.Enabled = true;
        }

        private static void BetaDecay(object neutron, ElapsedEventArgs elapsedEventArgs)
        {
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();
            universe.SubatomicParticles.Remove(neutron);
            universe.SubatomicParticles.Add(new Proton());
            universe.SubatomicParticles.Add(new Electron());
        }
    }
}
