namespace Neutron.UnitTests.DataModels
{
    using Neutron.DataModels;
    using Xunit;

    public class NeutronTests
    {
        [Fact]
        public void CanMakeNeutron()
        {
            var neutron = new Neutron();

            Assert.NotNull(neutron);
            Assert.Equal(Neutron.NeutronConstantChargeType, neutron.Charge);
            Assert.Equal(Neutron.NeutronConstantMass, neutron.Mass);
        }
    }
}
