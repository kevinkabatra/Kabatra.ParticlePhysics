namespace SubatomicParticles.UnitTests.DataModels
{
    using SubatomicParticles.DataModels;
    using Xunit;

    public abstract class SubatomicParticleTests<T> where T : SubatomicParticle, new()
    {
        /// <summary>
        ///     Validates that a particle can be created.
        /// </summary>
        [Fact]
        public void CanMakeParticle()
        {
            var particle = new T();
            Assert.NotNull(particle);
            ValidateCreation(particle);
        }

        /// <summary>
        ///     Validates that two particles of a given type are interchangeable.
        /// </summary>
        [Fact]
        public void CanTestEqualityOfParticles()
        {
            var particleA = new T();
            var particleB = new T();

            Assert.Equal(particleA, particleB);
        }

        /// <summary>
        ///     Validates that a particle is added to the Universe upon creation.
        /// </summary>
        [Fact]
        public void ParticleIsAddedToUniverseUponCreation()
        {
            var particle = new T();
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();

            Assert.Contains(particle, universe.SubatomicParticles);
        }

        /// <summary>
        ///     Test against expected constants to validate that the particle was created correctly.
        /// </summary>
        /// <param name="particle">The particle to be tested.</param>
        protected abstract void ValidateCreation(T particle);
    }
}
