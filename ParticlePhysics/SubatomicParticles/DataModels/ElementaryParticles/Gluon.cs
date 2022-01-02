namespace SubatomicParticles.DataModels.ElementaryParticles
{
    using Constants;
    using Interfaces.ElementaryParticles;

    /// <inheritdoc cref="IGluon"/>
    public class Gluon : ElementaryParticle, IGluon
    {
        public const ChargeType ConstantChargeType = ChargeType.Neutral;
        public const double ConstantChargeValue = 0d;
        public static readonly double ConstantMassInKilograms = 0d;
        public const double ConstantMassInElectronVolts = 0d;

        public Gluon() : base(ConstantChargeType, ConstantChargeValue, ConstantMassInKilograms, ConstantMassInElectronVolts)
        {
        }
    }
}
