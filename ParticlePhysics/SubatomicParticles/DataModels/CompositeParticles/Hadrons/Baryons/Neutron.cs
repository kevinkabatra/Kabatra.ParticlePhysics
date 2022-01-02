namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using System.Timers;
    using Constants;
    using ElementaryParticles;
    using ElementaryParticles.Quarks;
    using Interfaces.ElementaryParticles.Quarks;

    /// <summary>
    ///     The neutron is a subatomic particle which has a neutral charge and a mass slightly greater than that of a Proton.
    /// <para>See the following article for more information:</para>
    /// <para>1. <a href="https://en.wikipedia.org/wiki/Neutron">Wikipedia: Neutron</a></para>
    /// </summary>
    public class Neutron : Baryon
    {
        public static readonly ICollection<IQuark> ConstantComposition = new List<IQuark>
        {
            new UpQuark(),
            new DownQuark(),
            new DownQuark()
        };

        public const ChargeType ConstantChargeType = ChargeType.Neutral;
        public const double ConstantChargeValue = 0d;
        public static readonly double ConstantMassInKilograms = 1.67492749804 * Math.Pow(10, -27);
        public const double ConstantMassInElectronVolts = 939.56542052;
        public static readonly int ConstantBetaDecayTimeInSeconds = 879;
        public static readonly int ConstantBetaDecayTimeInMilliseconds = ConstantBetaDecayTimeInSeconds * 1000;

        public Timer BetaDecayEvent;

        public Neutron() : base(ConstantComposition, ConstantGluons, ConstantMassInKilograms, ConstantMassInElectronVolts)
        {
            BetaDecayEvent = new Timer(ConstantBetaDecayTimeInMilliseconds);
            BetaDecayEvent.Elapsed += BetaDecay;
            BetaDecayEvent.AutoReset = false;
            BetaDecayEvent.Enabled = true;
        }

        /// <summary>
        ///     When outside of a nucleus neutrons are unstable and will decay.
        /// <para>See the following article for more information:</para>
        /// <para><a href="https://en.wikipedia.org/wiki/Free_neutron_decay">Free neutron decay</a></para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="elapsedEventArgs"></param>
        private void BetaDecay(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();
            universe.SubatomicParticles.Remove(this);

            // Discard the new instances, they automatically add themselves to the universe.
            // https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/discards
            _ = new Proton();
            _ = new Electron();
        }
    }
}
