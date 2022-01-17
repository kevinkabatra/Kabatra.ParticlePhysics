namespace Universe.UnitTests.Utilities
{
    using Autofac;
    using Interfaces;
    using InversionOfControlDataModels;

    public class UniverseUtility
    {
        private IContainer UniverseContainer { get; set; }

        public UniverseUtility()
        {
            var bigBang = new ContainerBuilder();
            bigBang.RegisterType<NonSingletonUniverse>().As<IUniverse>();
            UniverseContainer = bigBang.Build();
        }

        public IUniverse GetNonSingletonUniverse()
        {
            using var scope = UniverseContainer.BeginLifetimeScope();
            return scope.Resolve<IUniverse>();
        }
    }
}
