namespace SubatomicParticles.UnitTests.DataModels
{
    using Interfaces;
    using SubatomicParticles.DataModels;
    using Xunit;

    public abstract class SubatomicParticleTests<TParticle, TParticleCreator> where TParticle : ISubatomicParticle, new() where TParticleCreator : ISubatomicParticleCreator<TParticle>, new()
    {
        /// <summary>
        ///     Validates that a particle can be created, this is how the creator will create the particles.
        /// </summary>
        [Fact]
        public void CanMakeParticle()
        {
            var particle = new TParticle();
            Assert.NotNull(particle);
            ValidateCreation(particle);
        }

        [Fact]
        public void CanMakeParticleWithCreator()
        {
            var particleCreator = new TParticleCreator();
            var particle = (TParticle) particleCreator.Create();
            ValidateCreation(particle);
        }

        /// <summary>
        ///     Validates that two particles of a given type are interchangeable.
        /// </summary>
        [Fact]
        public void CanTestEqualityOfParticles()
        {
            var particleA = new TParticle();
            var particleB = new TParticle();

            Assert.Equal(particleA, particleB);
        }

        /// <summary>
        ///     Validates that a particle is added to the Universe upon creation.
        /// </summary>
        [Fact]
        public void ParticleIsAddedToUniverseUponCreation()
        {
            var particle = new TParticle();
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();

            Assert.Contains(particle, universe.SubatomicParticles);
        }

        /// <summary>
        ///     Test against expected constants to validate that the particle was created correctly.
        /// </summary>
        /// <param name="particle">The particle to be tested.</param>
        protected abstract void ValidateCreation(TParticle particle);
    }
}
