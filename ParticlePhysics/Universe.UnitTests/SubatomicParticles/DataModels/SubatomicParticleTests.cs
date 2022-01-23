namespace Universe.UnitTests.SubatomicParticles.DataModels
{
    using global::Universe.SubatomicParticles.DataModels;
    using global::Universe.SubatomicParticles.Interfaces;
    using global::Universe.Universe.DataModels;
    using global::Universe.Universe.Utilities;
    using MatterCreation;
    using Xunit;

    public abstract class SubatomicParticleTests<TParticle, TParticleCreator> where TParticle : ISubatomicParticle, new() where TParticleCreator : SubatomicParticleCreator<TParticle>, new()
    {
        private readonly SubatomicParticleCreator<TParticle> _subatomicParticleCreator;

        protected SubatomicParticleTests()
        {
            _subatomicParticleCreator = new TParticleCreator();
            UniverseUtility<Universe>.GetOrCreateUniverse().RegisterMatterCreationEvent(_subatomicParticleCreator);
        }

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
            var particle = (TParticle)_subatomicParticleCreator.Create();
            ValidateCreation(particle);
        }

        [Fact]
        public void MatterCreationEventTriggeredOnParticleCreation()
        {
            var particleCreated = Assert.Raises<MatterCreationEvent>(
                attach => _subatomicParticleCreator.MatterCreation += attach,
                detach => _subatomicParticleCreator.MatterCreation -= detach,
                () => _subatomicParticleCreator.Create()
            ).Arguments.Particle;
            Assert.NotNull(particleCreated);

            var expectedParticle = new TParticle();
            Assert.Equal(expectedParticle, particleCreated);
        }

        /// <summary>
        ///     Validates that two particles of a given type are interchangeable.
        /// </summary>
        [Fact]
        public void CanTestEqualityOfParticles()
        {
            var particleA = _subatomicParticleCreator.Create();
            var particleB = _subatomicParticleCreator.Create();

            Assert.Equal(particleA, particleB);
        }

        /// <summary>
        ///     Validates that a particle is added to the Universe upon creation.
        /// </summary>
        [Fact]
        public void ParticleIsAddedToUniverseUponCreation()
        {
            var particle = (TParticle) _subatomicParticleCreator.Create();
            var universe = Universe.GetOrCreateInstance();

            Assert.Contains(particle, universe.SubatomicParticles);
        }

        /// <summary>
        ///     Test against expected constants to validate that the particle was created correctly.
        /// </summary>
        /// <param name="particle">The particle to be tested.</param>
        protected abstract void ValidateCreation(TParticle particle);
    }
}
