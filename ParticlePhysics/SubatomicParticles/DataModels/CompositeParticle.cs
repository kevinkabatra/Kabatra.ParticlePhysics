namespace SubatomicParticles.DataModels
{
    using Constants;
    using Interfaces;

    public abstract class CompositeParticle : SubatomicParticle, ICompositeParticle
    {
        protected CompositeParticle(ChargeType charge, double mass) : base(charge, mass)
        {
        }
    }
}
