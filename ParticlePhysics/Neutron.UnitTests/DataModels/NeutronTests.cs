namespace SubatomicParticles.UnitTests.DataModels
{
    using SubatomicParticles.DataModels;
    using Xunit;

    public class NeutronTests
    {
        [Fact]
        public void CanMakeNeutron()
        {
            var neutron = new Neutron();

            Assert.NotNull(neutron);
            Assert.Equal(Neutron.ConstantChargeType, neutron.Charge);
            Assert.Equal(Neutron.ConstantMass, neutron.Mass);
        }

        [Fact]
        public void CanDecayIntoProtonAndElectron()
        {
            Universe.DataModels.Universe.Reset();
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();
            
            var neutron = new Neutron();

            // Wait for the neutron to decay
            System.Threading.Thread.Sleep(Neutron.ConstantBetaDecayTimeInMilliseconds + 10);
            
            Assert.NotNull(universe);
            Assert.Equal(2, universe.SubatomicParticles.Count);
        }
    }
}
