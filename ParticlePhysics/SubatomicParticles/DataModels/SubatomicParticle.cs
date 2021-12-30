namespace SubatomicParticles.DataModels
{
    using Constants;
    using Interfaces;

    /// <inheritdoc cref="ISubatomicParticle"/>
    public abstract class SubatomicParticle : ISubatomicParticle
    {
        protected SubatomicParticle(ChargeType charge, double mass)
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
