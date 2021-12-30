namespace SubatomicParticles.DataModels
{
    using Constants;
    using Interfaces;

    /// <inheritdoc cref="IElementaryParticle"/>
    public abstract class ElementaryParticle : SubatomicParticle, IElementaryParticle
    {
        protected ElementaryParticle(ChargeType charge, double mass) : base(charge, mass)
        {
        }
    }
}
