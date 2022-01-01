namespace SubatomicParticles.UnitTests.DataModels.CompositeParticles.Hadrons.Baryons
{
    using SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons;
    using Xunit;

    public class ProtonTests : SubatomicParticleTest
    {
        [Fact]
        public void CanMakeProton()
        {
            var proton = new Proton();

            Assert.NotNull(proton);
            Assert.Equal(Proton.ConstantChargeType, proton.Charge);
            Assert.Equal(Proton.ConstantMassInKilograms, proton.MassInKilograms);
        }

        [Fact]
        public void ProtonIsAddedToUniverseUponCreation()
        {
            var proton = new Proton();
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();

            Assert.Contains(proton, universe.SubatomicParticles);
        }
    }
}
