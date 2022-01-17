namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons.Pions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using ElementaryParticles.Quarks;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;

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
}
