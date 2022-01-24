namespace Universe.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using ElementaryParticles.Quarks;
    using Events;
    using Events.MatterCreation;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;

    public class Antiproton : Baryon
    {
        public const ChargeType ConstantChargeType = ChargeType.Negative;
        public const double ConstantChargeValue = Proton.ConstantChargeValue * -1;
        public static readonly double ConstantMassInKilograms = Proton.ConstantMassInKilograms;
        public const double ConstantMassInElectronVolts = Proton.ConstantMassInElectronVolts;
        public static readonly Type ConstantAntiparticleType = typeof(Proton);

        public static readonly ICollection<IQuark> ConstantComposition = new List<IQuark>
        {
            new AntiUpQuark(),
            new AntiUpQuark(),
            new AntiDownQuark()
        };

        public Antiproton() : base(ConstantComposition, ConstantGluons, ConstantMassInKilograms, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
        }

        public Antiproton(ICollection<IQuark> quarks, ICollection<IGluon> gluons) : base(quarks, gluons, ConstantMassInKilograms, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
            var numberOfAntiUpQuarks = quarks.OfType<AntiUpQuark>().Count();
            var numberOfAntiDownQuarks = quarks.OfType<AntiDownQuark>().Count();

            if (numberOfAntiUpQuarks != 2 && numberOfAntiDownQuarks != 1)
            {
                throw new ArgumentException($"A Antiproton requires two (2) AntiUp Quark and one (1) AntiDown Quark. This Antiproton contains {numberOfAntiUpQuarks} AntiUp Quarks and {numberOfAntiDownQuarks} AntiDown Quarks.");
            }
        }
    }

    /// <inheritdoc cref="SubatomicParticleCreator{T}"/>
    public class AntiprotonCreator : CompositeParticleCreator<Antiproton>
    {
        /// <inheritdoc cref="CompositeParticleCreator{T}.Create(ICollection{IQuark},ICollection{IGluon})"/>
        public override Antiproton Create(ICollection<IQuark> quarks, ICollection<IGluon> gluons)
        {
            var antiproton = new Antiproton(quarks, gluons);
            TriggerMatterCreationEvent(new MatterCreationEvent(antiproton));

            return antiproton;
        }
    }
}
