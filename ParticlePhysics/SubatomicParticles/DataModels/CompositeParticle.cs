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

            // Add this new particle to the Universe
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();
            universe.SubatomicParticles.Add(this);
        }

        public ChargeType Charge { get; }
        public double Mass { get; }
    }
}
