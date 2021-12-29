namespace SubatomicParticles.UnitTests.DataModels
{
    using SubatomicParticles.DataModels;
    using Xunit;

    public class ProtonTests
    {
        [Fact]
        public void CanMakeProton()
        {
            var proton = new Proton();

            Assert.NotNull(proton);
            Assert.Equal(Proton.ConstantChargeType, proton.Charge);
            Assert.Equal(Proton.ConstantMass, proton.Mass);
        }
    }
}
