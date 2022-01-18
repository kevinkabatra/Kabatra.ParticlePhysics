namespace Universe.Utilities
{
    using Autofac;
    using Interfaces;

    /// <summary>
    ///     Uses inversion of control to determine which type of Universe to return.
    /// </summary>
    /// <typeparam name="T">The data model of the Universe that should be returned.</typeparam>
    public class UniverseUtility<T> where T : IUniverse
    {
        private IContainer UniverseContainer { get; }

        /// <summary>
        ///     Uses inversion of control to identify which type of Universe should be retrieved.
        /// </summary>
        protected  UniverseUtility()
        {
            var bigBang = new ContainerBuilder();
            bigBang.RegisterType<T>().As<IUniverse>();
            UniverseContainer = bigBang.Build();
        }

        /// <summary>
        ///     Gets or creates the Universe.
        /// </summary>
        /// <typeparam name="TIUniverse"></typeparam>
        /// <returns></returns>
        public static IUniverse GetOrCreateUniverse<TIUniverse>() where TIUniverse : IUniverse
        {
            var universeUtility = new UniverseUtility<TIUniverse>();
            return universeUtility.GetUniverse();
        }

        /// <summary>
        ///     Gets the universe.
        /// </summary>
        /// <returns></returns>
        private IUniverse GetUniverse()
        {
            using var scope = UniverseContainer.BeginLifetimeScope();
            return scope.Resolve<IUniverse>().Get;
        }
    }
}
