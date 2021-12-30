namespace SubatomicParticles.DataModels
{
    using Constants;
    using Interfaces;

    /// <inheritdoc cref="ICompositeParticle"/>
    public abstract class CompositeParticle : SubatomicParticle, ICompositeParticle
    {
        protected CompositeParticle(ChargeType charge, double mass) : base(charge, mass)
        {
        }
    }
}
