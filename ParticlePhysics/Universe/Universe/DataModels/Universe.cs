namespace Universe.Universe.DataModels
{
    using System;
    using System.Collections.Generic;
    using Constants;
    using Interfaces;
    using Kabatra.Common.Singleton;
    using MatterCreation;
    using SubatomicParticles.DataModels;
    using SubatomicParticles.Interfaces;

    //ToDo: Will need to create an Event for handling Beta Minus Decay, since the original particle will need to be removed from the Universe

    /// <inheritdoc cref="IUniverse"/>
    public class Universe : SingletonBase<Universe>, IUniverse
    {
        public List<object> SubatomicParticles;

        public const Epoch ConstantUniverseFirstEpoch = Epoch.PlanckEpoch;
        public static readonly double ConstantUniverseFirstTemperatureInKelvin = Math.Pow(10, 32);
        public static readonly double ConstantUniverseFirstTimeInSeconds = Math.Pow(10, -43);

        /// <inheritdoc cref="IUniverse"/>
        public Universe()
        {
            SubatomicParticles = new List<object>();
            Epoch = ConstantUniverseFirstEpoch;
            TemperatureInKelvin = ConstantUniverseFirstTemperatureInKelvin;
            TimeInSeconds = ConstantUniverseFirstTimeInSeconds;
        }

        /// <inheritdoc cref="IUniverse.Epoch"/>
        public Epoch Epoch { get; private set; }

        /// <inheritdoc cref="IUniverse.Get"/>
        public IUniverse Get => Universe.GetOrCreateInstance();

        /// <inheritdoc cref="IUniverse.NextEpoch"/>
        public void NextEpoch()
        {
            var currentEpochAsInt = (int)Epoch;
            Epoch = (Epoch)(currentEpochAsInt + 1);

            SetPropertiesBasedOnEpoch();
        }

        /// <inheritdoc cref="IUniverse.TemperatureInKelvin"/>
        public double TemperatureInKelvin { get; private set; }

        /// <inheritdoc cref="IUniverse.TimeInSeconds"/>
        public double TimeInSeconds { get; private set; }

        /// <inheritdoc cref="IUniverse.RegisterMatterCreationEvent{T}"/>
        public void RegisterMatterCreationEvent<T>(SubatomicParticleCreator<T> subatomicParticleCreator) where T : ISubatomicParticle, new()
        {
            subatomicParticleCreator.MatterCreation += AddSubatomicParticleToUniverse;
        }

        /// <inheritdoc cref="IUniverse.SetEpoch"/>
        public void SetEpoch(Epoch epoch)
        {
            Epoch = epoch;
            SetPropertiesBasedOnEpoch();
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

        /// <summary>
        ///     Updates the temperature and time based on the epoch.
        /// </summary>
        private void SetPropertiesBasedOnEpoch()
        {
            switch (Epoch)
            {
                case Epoch.InflationaryEpoch:
                    TemperatureInKelvin = Math.Pow(10, 28);
                    TimeInSeconds = Math.Pow(10, -32);
                    break;

                case Epoch.BeginningQuarkEpoch:
                    TemperatureInKelvin = Math.Pow(10, 15);
                    TimeInSeconds = Math.Pow(10, -12);
                    break;

                case Epoch.EndQuarkEpoch:
                    TemperatureInKelvin = Math.Pow(10, 12);
                    TimeInSeconds = Math.Pow(10, -5);
                    break;

                case Epoch.PlanckEpoch:
                default:
                    break;
            }
        }
    }
}
