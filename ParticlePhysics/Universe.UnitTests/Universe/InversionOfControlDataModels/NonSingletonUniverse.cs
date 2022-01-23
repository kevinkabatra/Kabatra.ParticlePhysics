namespace Universe.UnitTests.Universe.InversionOfControlDataModels
{
    using System.Collections.Generic;
    using global::Universe.SubatomicParticles.DataModels;
    using global::Universe.SubatomicParticles.Interfaces;
    using global::Universe.Universe.Constants;
    using global::Universe.Universe.DataModels;
    using global::Universe.Universe.Interfaces;
    using MatterCreation;

    /// <summary>
    ///     A Universe that is not a Singleton, this will be used for isolated testing of
    /// particle creation.
    /// </summary>
    public class NonSingletonUniverse : IUniverse
    {
        public List<object> SubatomicParticles;

        /// <inheritdoc cref="IUniverse"/>
        public NonSingletonUniverse()
        {
            SubatomicParticles = new List<object>();
            Epoch = Universe.ConstantUniverseFirstEpoch;
            TemperatureInKelvin = Universe.ConstantUniverseFirstTemperatureInKelvin;
            TimeInSeconds = Universe.ConstantUniverseFirstTimeInSeconds;
        }

        /// <inheritdoc cref="IUniverse.Epoch"/>
        public Epoch Epoch { get; private set; }

        public IUniverse Get => new NonSingletonUniverse();

        /// <inheritdoc cref="IUniverse.TemperatureInKelvin"/>
        public double TemperatureInKelvin { get; private set; }

        /// <inheritdoc cref="IUniverse.TimeInSeconds"/>
        public double TimeInSeconds { get; private set; }

        /// <inheritdoc cref="IUniverse.NextEpoch"/>
        public void NextEpoch()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc cref="IUniverse.RegisterMatterCreationEvent{T}"/>
        public void RegisterMatterCreationEvent<T>(SubatomicParticleCreator<T> subatomicParticleCreator) where T : ISubatomicParticle, new()
        {
            subatomicParticleCreator.MatterCreation += AddSubatomicParticleToUniverse;
        }

        /// <inheritdoc cref="IUniverse.SetEpoch"/>
        public void SetEpoch(Epoch epoch)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///     Adds the created subatomic particle to the Universe.
        /// </summary>
        /// <param name="sender">The subatomic particle creator.</param>
        /// <param name="matterCreationEvent">The event that contains the particle to add.</param>
        private void AddSubatomicParticleToUniverse(object sender, MatterCreationEvent matterCreationEvent)
        {
            SubatomicParticles.Add(matterCreationEvent.Particle);
        }
    }
}
