namespace SubatomicParticles.UnitTests.DataModels
{
    using SubatomicParticles.DataModels;
    using Xunit;

    public class ElectronTests : SubatomicParticleTest
    {
        [Fact]
        public void CanMakeElectron()
        {
            var electron = new Electron();

            Assert.NotNull(electron);
            Assert.Equal(Electron.ConstantChargeType, electron.Charge);
            Assert.Equal(Electron.ConstantMass, electron.Mass);
        }

        [Fact]
        public void ElectronIsAddedToUniverseUponCreation()
        {
            var electron = new Electron();
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();

            Assert.Contains(electron, universe.SubatomicParticles);
        }
    }
}
