namespace SubatomicParticles.DataModels.ElementaryParticles.Quarks
{
    using System;
    using Constants;
    using MatterCreation;

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

    /// <inheritdoc cref="SubatomicParticleCreator{T}"/>
    public class AntiDownQuarkCreator : SubatomicParticleCreator<AntiDownQuark>
    {
        /// <inheritdoc cref="SubatomicParticleCreator{T}.Create"/>
        public override AntiDownQuark Create()
        {
            var antiDownQuark = new AntiDownQuark();
            TriggerMatterCreationEvent(new MatterCreationEvent(antiDownQuark));

            return antiDownQuark;
        }
    }
}
