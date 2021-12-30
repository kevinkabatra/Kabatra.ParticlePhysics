namespace Universe.UnitTests.DataModels
{
    using Xunit;

    public class UniverseTests
    {
        [Fact]
        public void CanGetOrCreateUniverseSingleton()
        {
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();

            Assert.NotNull(universe);
        }
    }
}
