namespace SubatomicParticles.UnitTests.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System.Linq;
    using SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons;
    using Xunit;

    public class ProtonTests : SubatomicParticleTest
    {
        [Fact]
        public void CanMakeProton()
        {
            var proton = new Proton();

            Assert.NotNull(proton);
            Assert.Collection(proton.Quarks,
                firstQuark => Assert.Equal(Proton.ConstantComposition.ToList()[0], firstQuark),
                secondQuark => Assert.Equal(Proton.ConstantComposition.ToList()[1], secondQuark),
                thirdQuark => Assert.Equal(Proton.ConstantComposition.ToList()[2], thirdQuark)
            );
            Assert.Equal(Baryon.ConstantGluons.Count, proton.Gluons.Count());
            Assert.Equal(Proton.ConstantChargeType, proton.Charge);
            Assert.Equal(Proton.ConstantChargeValue, proton.ChargeValue);
            Assert.Equal(Proton.ConstantMassInKilograms, proton.MassInKilograms);
            Assert.Equal(Proton.ConstantMassInElectronVolts, proton.MassInElectronVolts);
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
