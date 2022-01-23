namespace Universe.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons.Pions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using ElementaryParticles.Quarks;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;
    using MatterCreation;

    /// <inheritdoc cref="Pion"/>
    public class PionPositive : Pion
    {
        public const ChargeType ConstantChargeType = ChargeType.Positive;
        public const double ConstantChargeValue = 1d;
        public const double ConstantMassInElectronVolts = 139.57039d;
        public static readonly Type ConstantAntiparticleType = typeof(PionNegative);

        public static readonly ICollection<IQuark> ConstantComposition = new List<IQuark>
        {
            new UpQuark(),
            new AntiDownQuark()
        };

        public PionPositive() : base(ConstantComposition, Meson.ConstantGluons, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
        }

        public PionPositive(ICollection<IQuark> quarks, ICollection<IGluon> gluons) : base(quarks, gluons, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
            var numberOfUpQuarks = quarks.OfType<UpQuark>().Count();
            var numberOfAntiDownQuarks = quarks.OfType<AntiDownQuark>().Count();

            if (numberOfUpQuarks != 1 && numberOfAntiDownQuarks != 1)
            {
                throw new ArgumentException($"A Positive Pion requires one (1) Up Quark and one (1) AntiDown Quark. This Positive Pion contains {numberOfUpQuarks} Up Quarks and {numberOfAntiDownQuarks} AntiDown Quarks.");
            }
        }
    }

    /// <inheritdoc cref="SubatomicParticleCreator{T}"/>
    public class PionPositiveCreator : CompositeParticleCreator<PionPositive>
    {
        /// <inheritdoc cref="SubatomicParticleCreator{T}.Create"/>
        public override PionPositive Create()
        {
            var pionPositive = new PionPositive();
            TriggerMatterCreationEvent(new MatterCreationEvent(pionPositive));

            return pionPositive;
        }

        /// <inheritdoc cref="CompositeParticleCreator{T}.Create(ICollection{IQuark},ICollection{IGluon})"/>
        public override PionPositive Create(ICollection<IQuark> quarks, ICollection<IGluon> gluons)
        {
            var pionPositive = new PionPositive(quarks, gluons);
            TriggerMatterCreationEvent(new MatterCreationEvent(pionPositive));

            return pionPositive;
        }
    }
}
