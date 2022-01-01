namespace SubatomicParticles.DataModels.CompositeParticles
{
    using Constants;
    using Interfaces.CompositeParticles;

    /// <inheritdoc cref="ICompositeParticle"/>
    public abstract class CompositeParticle : SubatomicParticle, ICompositeParticle
    {
        protected CompositeParticle(ChargeType charge, double chargeValue, double? massInKilograms, double? massInElectronVolts) : base(charge, chargeValue, massInKilograms, massInElectronVolts)
        {
        }
    }
}
