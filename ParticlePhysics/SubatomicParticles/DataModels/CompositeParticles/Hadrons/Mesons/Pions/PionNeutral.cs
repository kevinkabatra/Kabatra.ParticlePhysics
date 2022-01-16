namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons.Pions
{
    using System;
    using System.Collections.Generic;
    using Constants;
    using ElementaryParticles.Quarks;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;

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

        public PionNeutral(ICollection<IQuark> quarks, ICollection<IGluon> gluons) : base(quarks, gluons, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
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
}
