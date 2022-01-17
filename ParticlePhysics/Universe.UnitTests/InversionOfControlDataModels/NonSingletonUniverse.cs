namespace Universe.UnitTests.InversionOfControlDataModels
{
    using System.Collections.Generic;
    using Constants;
    using Interfaces;
    using Universe.DataModels;

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

        /// <inheritdoc cref="IUniverse.TemperatureInKelvin"/>
        public double TemperatureInKelvin { get; private set; }

        /// <inheritdoc cref="IUniverse.TimeInSeconds"/>
        public double TimeInSeconds { get; private set; }

        /// <inheritdoc cref="IUniverse.NextEpoch"/>
        public void NextEpoch()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc cref="IUniverse.SetEpoch"/>
        public void SetEpoch(Epoch epoch)
        {
            throw new System.NotImplementedException();
        }
    }
}
