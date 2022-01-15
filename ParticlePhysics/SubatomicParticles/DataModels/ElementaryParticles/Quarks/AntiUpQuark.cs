namespace SubatomicParticles.DataModels.ElementaryParticles.Quarks
{
    using System;
    using Constants;

    public class AntiUpQuark : Quark
    {
        public const ChargeType ConstantChargeType = ChargeType.Negative;
        public const double ConstantChargeValue = UpQuark.ConstantChargeValue * -1;
        public const double ConstantMassInElectronVolts = UpQuark.ConstantMassInElectronVolts;
        public static readonly Type ConstantAntiparticleType = typeof(UpQuark);

        public AntiUpQuark() : base(QuarkFlavor.Up, ConstantChargeType, ConstantChargeValue, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
        }
    }
}
