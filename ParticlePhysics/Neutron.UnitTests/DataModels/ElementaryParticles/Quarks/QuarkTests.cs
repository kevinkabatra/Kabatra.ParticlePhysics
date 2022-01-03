namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles.Quarks
{
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Xunit;

    public abstract class QuarkTests<T> where T : Quark, new()
    {
        [Fact]
        public void QuarkIsAddedToUniverseUponCreation()
        {
            var quark = new T();
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();

            Assert.Contains(quark, universe.SubatomicParticles);
        }
    }
}
