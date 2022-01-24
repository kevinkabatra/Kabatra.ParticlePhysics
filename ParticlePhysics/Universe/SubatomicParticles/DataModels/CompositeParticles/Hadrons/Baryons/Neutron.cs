namespace Universe.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Timers;
    using Constants;
    using ElementaryParticles;
    using ElementaryParticles.Quarks;
    using Events;
    using Events.BetaDecay;
    using Events.MatterCreation;
    using Interfaces;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;

    /// <summary>
    ///     The neutron is a subatomic particle which has a neutral charge and a mass slightly greater than that of a Proton.
    /// <para>See the following article for more information:</para>
    /// <para>1. <a href="https://en.wikipedia.org/wiki/Neutron">Wikipedia: Neutron</a></para>
    /// </summary>
    public class Neutron : Baryon
    {
        public const ChargeType ConstantChargeType = ChargeType.Neutral;
        public const double ConstantChargeValue = 0d;
        public static readonly double ConstantMassInKilograms = 1.67492749804 * Math.Pow(10, -27);
        public const double ConstantMassInElectronVolts = 939.56542052;
        public static readonly int ConstantBetaDecayTimeInSeconds = 879;
        public static readonly int ConstantBetaDecayTimeInMilliseconds = ConstantBetaDecayTimeInSeconds * 1000;
        public static readonly Type ConstantAntiparticleType = typeof(Antineutron);

        // ToDo: the bug still exists, I need to convert this into a function
        public static readonly  ICollection<IQuark> ConstantComposition = new List<IQuark>
        {
            new UpQuarkCreator().Create(),
            new DownQuarkCreator().Create(),
            new DownQuarkCreator().Create()
        };

        public BetaDecayTimer BetaDecayEventTimer;

        public Neutron() : base(ConstantComposition, ConstantGluons, ConstantMassInKilograms, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
        }

        public Neutron(ICollection<IQuark> quarks, ICollection<IGluon> gluons) : base(quarks, gluons, ConstantMassInKilograms, ConstantMassInElectronVolts, ConstantAntiparticleType)
        { 
            var numberOfUpQuarks = quarks.OfType<UpQuark>().Count();
            var numberOfDownQuarks = quarks.OfType<DownQuark>().Count();

            if (numberOfUpQuarks != 1 && numberOfDownQuarks != 2)
            {
                throw new ArgumentException($"A Neutron requires one (1) Up Quark and two (2) Down Quarks. This Neutron contains {numberOfUpQuarks} Up Quarks and {numberOfDownQuarks} Down Quarks.");
            }
        }
    }

    /// <inheritdoc cref="SubatomicParticleCreator{T}"/>
    public class NeutronCreator : CompositeParticleCreator<Neutron>
    {
        /// <inheritdoc cref="SubatomicParticleCreator{T}.Create"/>
        public override Neutron Create()
        {
            var neutron = (Neutron) base.Create();
            SetBetaMinusDecayTimer(ref neutron);
            
            return neutron;
        }

        /// <inheritdoc cref="CompositeParticleCreator{T}.Create(ICollection{IQuark},ICollection{IGluon})"/>
        public override Neutron Create(ICollection<IQuark> quarks, ICollection<IGluon> gluons)
        {
            var neutron = new Neutron(quarks, gluons);
            TriggerMatterCreationEvent(new MatterCreationEvent(neutron));
            SetBetaMinusDecayTimer(ref neutron);

            return neutron;
        }

        /// <summary>
        ///     When outside of a nucleus neutrons are unstable and will decay.
        /// <para>See the following article for more information:</para>
        /// <para><a href="https://en.wikipedia.org/wiki/Free_neutron_decay">Free neutron decay</a></para>
        /// </summary>
        /// <param name="timer"></param>
        /// <param name="elapsedEventArgs"></param>
        private void BetaMinusDecay(object timer, ElapsedEventArgs elapsedEventArgs)
        {
            var betaDecayEventTimer = (BetaDecayTimer) timer;
            if (betaDecayEventTimer == null)
            {
                throw new Exception("Timer is not of time BetaDecayEvent");
            }

            TriggerBetaDecayEvent(betaDecayEventTimer.BetaDecayEvent);

            //var universe = global::Universe.Universe.DataModels.Universe.GetOrCreateInstance();
            //universe.SubatomicParticles.Remove(this);

            // Discard the new instances, they automatically add themselves to the universe.
            // https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/discards
            //_ = new Proton();
            //_ = new Electron();
            
        }

        /// <summary>
        ///     Sets a timer for the beta minus decay of a neutron.
        /// </summary>
        private void SetBetaMinusDecayTimer(ref Neutron neutron)
        {
            //ToDo: figure out how to create once the event is thrown and not before
            var particlesThatAreCreatedDueToDecay = new List<object>
            {
                new ProtonCreator().Create(),
                new ElectronCreator().Create(),
                //ToDo: I need to make an Antineutrino, probably means that I need a Neutrino as well. Change to Antineutrino once created
                new ElectronCreator().Create()
            };

            var betaDecayEvent = new BetaDecayEvent(neutron, particlesThatAreCreatedDueToDecay);


            neutron.BetaDecayEventTimer = new BetaDecayTimer(betaDecayEvent, Neutron.ConstantBetaDecayTimeInMilliseconds);
            neutron.BetaDecayEventTimer.Elapsed += BetaMinusDecay;
            neutron.BetaDecayEventTimer.AutoReset = false;
            neutron.BetaDecayEventTimer.Enabled = true;
        }
    }
}
