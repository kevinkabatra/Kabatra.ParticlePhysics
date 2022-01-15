namespace SubatomicParticles.DataModels.ElementaryParticles
{
    using System;
    using Constants;
    using Interfaces.ElementaryParticles;

    /// <inheritdoc cref="IElementaryParticle"/>
    public abstract class ElementaryParticle : SubatomicParticle, IElementaryParticle
    {
        protected ElementaryParticle(ChargeType charge, double chargeValue, double? massInKilograms, double? massInElectronVolts, Type antiParticle) : base(charge, chargeValue, massInKilograms, massInElectronVolts, antiParticle)
        {
        }
    }
}
