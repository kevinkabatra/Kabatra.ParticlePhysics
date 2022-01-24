namespace Universe.SubatomicParticles.DataModels.ElementaryParticles.Quarks
{
    using System;
    using Constants;
    using Events;
    using Events.MatterCreation;

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

    /// <inheritdoc cref="SubatomicParticleCreator{T}"/>
    public class AntiUpQuarkCreator : SubatomicParticleCreator<AntiUpQuark>
    {
        /// <inheritdoc cref="SubatomicParticleCreator{T}.Create"/>
        public override AntiUpQuark Create()
        {
            var antiUpQuark = new AntiUpQuark();
            TriggerMatterCreationEvent(new MatterCreationEvent(antiUpQuark));

            return antiUpQuark;
        }
    }
}
