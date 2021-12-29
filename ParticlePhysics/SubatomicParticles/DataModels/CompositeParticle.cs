namespace SubatomicParticles.DataModels
{
    using Constants;
    using Interfaces;

    public abstract class CompositeParticle: ICompositeParticle
    {
        protected CompositeParticle(ChargeType charge, double mass)
        {
            Charge = charge;
            Mass = mass;
        }

        public ChargeType Charge { get; }
        public double Mass { get; }
    }
}
