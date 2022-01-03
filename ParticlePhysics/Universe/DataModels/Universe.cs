namespace Universe.DataModels
{
    using System;
    using System.Collections.Generic;
    using Constants;
    using Kabatra.Common.Singleton;

    /// <summary>
    ///     All of space and time and their contents.
    /// <para>All of the subatomic particles that are created are added to the universe upon creation.
    /// The universe is a singleton object as there is only one universe in real-life.</para>
    /// <para>See the following articles for more information:</para>
    /// <para>1. <a href="https://en.wikipedia.org/wiki/Universe">Wikipedia: Universe</a></para>
    /// <para>2. <a href="https://lco.global/spacebook/cosmology/early-universe/">The Early Universe</a></para>
    /// </summary>
    public class Universe : SingletonBase<Universe>
    {
        public List<object> SubatomicParticles;

        public Universe()
        {
            SubatomicParticles = new List<object>();
            Epoch = Epoch.PlanckEpoch;
            TemperatureInKelvin = Math.Pow(10, 32);
            TimeInSeconds = Math.Pow(10, -43);
        }

        public Epoch Epoch { get; private set; }
        public double TemperatureInKelvin { get; private set; }
        public double TimeInSeconds { get; private set; }

        public void NextEpoch()
        {
            var currentEpochAsInt = (int) Epoch;
            Epoch = (Epoch) (currentEpochAsInt + 1);

            SetPropertiesBasedOnEpoch();
        }

        public void SetEpoch(Epoch epoch)
        {
            Epoch = epoch;
            SetPropertiesBasedOnEpoch();
        }

        private void SetPropertiesBasedOnEpoch()
        {
            switch (Epoch)
            {
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
