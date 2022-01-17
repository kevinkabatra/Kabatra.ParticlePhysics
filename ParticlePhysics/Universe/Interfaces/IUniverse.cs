namespace Universe.Interfaces
{
    using Constants;

    /// <summary>
    ///     All of space and time and their contents.
    /// <para>All of the subatomic particles that are created are added to the universe upon creation.
    /// The universe is a singleton object as there is only one universe in real-life.</para>
    /// <para>See the following articles for more information:</para>
    /// <para>1. <a href="https://en.wikipedia.org/wiki/Universe">Wikipedia: Universe</a></para>
    /// <para>2. <a href="https://lco.global/spacebook/cosmology/early-universe/">The Early Universe</a></para>
    /// </summary>
    public interface IUniverse
    {
        /// <summary>
        ///     Current epoch of the Universe, when the epoch is updated the temperature and time is adjusted.
        /// </summary>
        public Epoch Epoch { get; }

        /// <summary>
        ///     Current temperature of the Universe, some forces behave differently based on the temperature.
        /// </summary>
        public double TemperatureInKelvin { get; }

        /// <summary>
        ///     Current time of the Universe, this is just informational as at the time of coding C# cannot run code in smaller iterations than a hundred nanoseconds.
        /// </summary>
        public double TimeInSeconds { get; }

        /// <summary>
        ///     Advances the current epoch to the next according to the current understanding of the Universe's chronology.
        /// </summary>
        public void NextEpoch();

        /// <summary>
        ///     Sets epoch to a specified epoch.
        /// </summary>
        /// <remarks>
        ///     Hic sic dracones. Time travel like this can cause the very physics of the universe to behave in unexpected ways.
        /// </remarks>
        public void SetEpoch(Epoch epoch);
    }
}
