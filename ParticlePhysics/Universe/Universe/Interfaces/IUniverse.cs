namespace Universe.Universe.Interfaces
{
    using Constants;
    using SubatomicParticles.DataModels;
    using SubatomicParticles.Interfaces;

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
        ///     Gets the Universe.
        /// </summary>
        /// <remarks>
        /// <para>
        ///     I am going to rant to explain my problem, and my awful solution to that problem. I like the idea
        /// of the Universe following the Singleton pattern, but Singletons really cause a huge amount annoyance
        /// when it comes to isolating data during parallel execution of unit tests. But if we think about this
        /// in a physical sense, there is only one universe (except in multiverse theories, and I am not coding
        /// for that, well I guess this change is going to make a multiverse... oh boy).
        /// </para>
        /// <para>
        ///     My current struggle is that when my tests execute in parallel there are many particles popping
        /// in and out of existence, and it is impossible to ask the Universe if it only contains n number of
        /// any particular subatomic particle, because another test could have easily created those same particles.
        /// To work around this a lot of my tests have just validated that the Universe contains particles of
        /// a particular type, and not validated the quantity of them. I think this is sufficient for most unit
        /// testing but I have a scenario where it is not, and if I do not solve this problem I will continue
        /// to introduce an issue back into the system.
        /// </para>
        /// <para>
        ///     ToDo: explain the bug, how it was repaired, but only for Neutrons, and how I reintroduced when I looked at Protons and liked that implementation better
        /// </para>
        /// <para>
        ///     ToDo: Explain how to resolve this using an isolated universe. Explain how it can be created using Dependency Injection
        /// </para>
        /// <para>
        ///     ToDo: Explain that interfaces cannot have static methods and static methods cannot implement an interface method
        ///     ToDo: Link to stackoverflow: https://stackoverflow.com/questions/9415257/how-can-i-implement-static-methods-on-an-interface
        ///     ToDo: This method will be implemented on all data models and in the case of Universe, it is just a wrapper for Universe.GetOrCreateInstance()
        /// </para>
        ///     ToDo: Explain that this is still gross, as you will have to create a new Universe() in order to call .Get() which seems silly because new Universe() would have already given me a Universe.
        ///     ToDo: Almost makes me want to rip out the Singleton aspect of the Universe, but that then complicates how each new particle can add itself to the Universe upon creation.
        /// <para>
        /// </para>
        /// </remarks>
        public IUniverse Get { get; }

        /// <summary>
        ///     Current epoch of the Universe, when the epoch is updated the temperature and time is adjusted.
        /// </summary>
        public Epoch Epoch { get; }

        /// <summary>
        ///     Advances the current epoch to the next according to the current understanding of the Universe's chronology.
        /// </summary>
        public void NextEpoch();

        /// <summary>
        ///     Current temperature of the Universe, some forces behave differently based on the temperature.
        /// </summary>
        public double TemperatureInKelvin { get; }

        /// <summary>
        ///     Current time of the Universe, this is just informational as at the time of coding C# cannot run code in smaller iterations than a hundred nanoseconds.
        /// </summary>
        public double TimeInSeconds { get; }

        /// <summary>
        ///     Registers a subscriber to the MatterCreationEvent of a given SubatomicParticleCreator.
        /// <para>See the following document on details for subscriber implementation.</para>
        /// <para><a href="https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-publish-events-that-conform-to-net-framework-guidelines.">How to publish events that conform to .NET Guidelines (C# Programming Guide)</a></para>
        /// </summary>
        /// <typeparam name="T">The type of subatomic particle that is being created.</typeparam>
        /// <param name="subatomicParticleCreator">The creator of the subatomic particle.</param>
        public void RegisterMatterCreationEvent<T>(SubatomicParticleCreator<T> subatomicParticleCreator) where T : ISubatomicParticle, new();

        /// <summary>
        ///     Sets epoch to a specified epoch.
        /// </summary>
        /// <remarks>
        ///     Hic sic dracones. Time travel like this can cause the very physics of the universe to behave in unexpected ways.
        /// </remarks>
        public void SetEpoch(Epoch epoch);
    }
}
