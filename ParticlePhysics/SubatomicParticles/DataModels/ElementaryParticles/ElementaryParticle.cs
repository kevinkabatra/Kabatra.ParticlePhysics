namespace SubatomicParticles.DataModels.ElementaryParticles
{
    using System.Diagnostics.CodeAnalysis;
    using Constants;
    using Interfaces;
    using Interfaces.ElementaryParticles;

    /// <inheritdoc cref="IElementaryParticle"/>
    public abstract class ElementaryParticle : SubatomicParticle, IElementaryParticle
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameterInConstructor")]
        protected ElementaryParticle(ChargeType charge, double chargeValue, double? massInKilograms, double? massInElectronVolts, IElementaryParticle antiParticle) : base(charge, chargeValue, massInKilograms, massInElectronVolts, antiParticle)
        {
        }
    }
}
