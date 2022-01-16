namespace SubatomicParticles.DataModels.ElementaryParticles.Quarks
{
    using System;
    using Constants;

    public class AntiDownQuark : Quark
    {
        public const ChargeType ConstantChargeType = ChargeType.Positive;
        public const double ConstantChargeValue = DownQuark.ConstantChargeValue * -1;
        public const double ConstantMassInElectronVolts = DownQuark.ConstantMassInElectronVolts;
        public static readonly Type ConstantAntiparticleType = typeof(DownQuark);

        public AntiDownQuark() : base(QuarkFlavor.Down, ConstantChargeType, ConstantChargeValue, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
        }
    }
}
