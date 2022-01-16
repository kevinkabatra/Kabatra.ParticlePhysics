namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons.Pions
{
    using System;
    using System.Collections.Generic;
    using Constants;
    using ElementaryParticles.Quarks;
    using Interfaces.ElementaryParticles.Quarks;

    /// <inheritdoc cref="Pion"/>
    public class PionNegative : Pion
    {
        public const ChargeType ConstantChargeType = ChargeType.Negative;
        public const double ConstantChargeValue = -1d;
        public const double ConstantMassInElectronVolts = 139.57039d;
        public static readonly Type ConstantAntiparticleType = typeof(PionPositive);

        public static readonly ICollection<IQuark> ConstantComposition = new List<IQuark>
        {
            new DownQuark(),
            new AntiUpQuark()
        };

        public PionNegative() : base(ConstantComposition, Meson.ConstantGluons, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
        }
    }
}
