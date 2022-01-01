namespace SubatomicParticles.DataModels
{
    using Constants;
    using Interfaces;

    /// <inheritdoc cref="IElementaryParticle"/>
    public abstract class ElementaryParticle : SubatomicParticle, IElementaryParticle
    {
        protected ElementaryParticle(ChargeType charge, double chargeValue, double? massInKilograms, double? massInElectronVolts) : base(charge, chargeValue, massInKilograms, massInElectronVolts)
        {
        }
    }
}
