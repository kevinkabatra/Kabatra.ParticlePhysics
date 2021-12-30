namespace Neutron.DataModels
{
    using System;
    using System.Timers;
    using SubatomicParticles.Constants;
    using SubatomicParticles.DataModels;

    public class Neutron : CompositeParticle
    {
        public const ChargeType NeutronConstantChargeType = ChargeType.Neutral;
        public static readonly double NeutronConstantMass = 1.67492749804 * Math.Pow(10, -27);
        public static readonly int NeutronConstantBetaDecayTimeInSeconds = 879;
        public static readonly int NeutronConstantBetaDecayTimeInMilliseconds = NeutronConstantBetaDecayTimeInSeconds * 1000;

        public Neutron() : base(NeutronConstantChargeType, NeutronConstantMass)
        {
            var betaDecayEvent = new Timer(NeutronConstantBetaDecayTimeInMilliseconds);
            betaDecayEvent.Elapsed += BetaDecay;
            betaDecayEvent.AutoReset = false;
            betaDecayEvent.Enabled = true;
        }

        private static void BetaDecay(object source, ElapsedEventArgs elapsedEventArgs)
        {
            Console.WriteLine("Create Proton and Electron.");
        }
    }
}
