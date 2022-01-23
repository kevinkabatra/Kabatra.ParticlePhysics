namespace Universe.UnitTests.Universe.DataModels
{
    using Xunit;

    public class UniverseTests
    {
        [Fact]
        public void CanGetOrCreateUniverseSingleton()
        {
            var universe = global::Universe.Universe.DataModels.Universe.GetOrCreateInstance();

            Assert.NotNull(universe);
        }
    }
}
