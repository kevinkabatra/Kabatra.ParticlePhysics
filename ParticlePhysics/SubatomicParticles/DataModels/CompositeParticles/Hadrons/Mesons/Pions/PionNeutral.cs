namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons.Pions
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
    public class PionNeutral : Pion
    {
        public const ChargeType ConstantChargeType = ChargeType.Neutral;
        public const double ConstantChargeValue = 0d;
        public const double ConstantMassInElectronVolts = 134.9768d;
        public static readonly Type ConstantAntiparticleType = typeof(PionNeutral);

        public static readonly ICollection<IQuark> ConstantCompositionUpQuarks = new List<IQuark>
        {
            new UpQuark(),
            new AntiUpQuark()
        };

        public static readonly ICollection<IQuark> ConstantCompositionDownQuarks = new List<IQuark>
        {
            new DownQuark(),
            new AntiDownQuark()
        };

        public PionNeutral() : base(ConstantCompositionUpQuarks, ConstantGluons, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
        }

        public PionNeutral(ICollection<IQuark> quarks, ICollection<IGluon> gluons) : base(quarks, gluons, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
            var numberOfUpQuarks = quarks.OfType<UpQuark>().Count();
            var numberOfDownQuarks = quarks.OfType<DownQuark>().Count();
            var numberOfAntiUpQuarks = quarks.OfType<AntiUpQuark>().Count();
            var numberOfAntiDownQuarks = quarks.OfType<AntiDownQuark>().Count();

            var compositionIsCorrect = numberOfUpQuarks == 1 && numberOfAntiUpQuarks == 1 || numberOfDownQuarks == 1 && numberOfAntiDownQuarks == 1;
            if (compositionIsCorrect == false)
            {
                throw new ArgumentException($"A Neutral Pion requires either one of the following configurations: 1: one (1) Up Quark and one (1) AntiUp Quark 2: one (1) Down Quark and one (1) AntiDown Quark. This Neutral Pion contains 1: {numberOfUpQuarks} Up Quarks and {numberOfAntiUpQuarks} AntiUp Quarks, 2: {numberOfDownQuarks} Down Quarks and {numberOfAntiDownQuarks} AntiDown Quarks.");
            }
        }

        public static PionNeutral PionNeutralUpQuarkComposition()
        {
            return new PionNeutral(ConstantCompositionUpQuarks, Meson.ConstantGluons);
        }

        public static PionNeutral PionNeutralDownQuarkComposition()
        {
            return new PionNeutral(ConstantCompositionDownQuarks, Meson.ConstantGluons);
        }
    }

    /// <inheritdoc cref="SubatomicParticleCreator{T}"/>
    public class PionNeutralCreator : CompositeParticleCreator<PionNeutral>
    {
        /// <inheritdoc cref="SubatomicParticleCreator{T}.Create"/>
        public override PionNeutral Create()
        {
            var pionNeutral = new PionNeutral();
            TriggerMatterCreationEvent(new MatterCreationEvent(pionNeutral));

            return pionNeutral;
        }

        /// <inheritdoc cref="CompositeParticleCreator{T}.Create(ICollection{IQuark},ICollection{IGluon})"/>
        public override PionNeutral Create(ICollection<IQuark> quarks, ICollection<IGluon> gluons)
        {
            var pionNeutral = new PionNeutral(quarks, gluons);
            TriggerMatterCreationEvent(new MatterCreationEvent(pionNeutral));

            return pionNeutral;
        }
    }
}
