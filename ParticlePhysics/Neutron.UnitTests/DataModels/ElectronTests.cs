namespace SubatomicParticles.UnitTests.DataModels
{
    using SubatomicParticles.DataModels;
    using Xunit;

    public class ElectronTests
    {
        [Fact]
        public void CanMakeElectron()
        {
            var electron = new Electron();

            Assert.NotNull(electron);
            Assert.Equal(Electron.ConstantChargeType, electron.Charge);
            Assert.Equal(Electron.ConstantMass, electron.Mass);
        }
    }
}
