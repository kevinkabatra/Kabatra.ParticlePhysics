namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles
{
    using SubatomicParticles.DataModels.ElementaryParticles;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Utilities;
    using Xunit;

    public class GluonTests : SubatomicParticleTest
    {
        [Fact]
        public void CanCreateGluon()
        {
            var gluon = new Gluon();

            Assert.NotNull(gluon);
            Assert.Null(gluon.QuarkA);
            Assert.Null(gluon.QuarkB);
            Assert.Equal(Gluon.ConstantChargeType, gluon.Charge);
            Assert.Equal(Gluon.ConstantChargeValue, gluon.ChargeValue);
            Assert.Equal(Gluon.ConstantMassInKilograms, gluon.MassInKilograms);
            Assert.Equal(Gluon.ConstantMassInElectronVolts, gluon.MassInElectronVolts);
        }

        [Fact]
        public void GluonIsAddedToUniverseUponCreation()
        {
            var gluon = new Gluon();
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();

            Assert.Contains(gluon, universe.SubatomicParticles);
        }

        [Fact]
        public void CanBindToQuarks()
        {
            _ = new UpQuark();
            _ = new UpQuark();

            var gluon = new Gluon();

            TimerUtility.FireTimerAndWait(gluon.AttachQuarkAEvent);
            TimerUtility.FireTimerAndWait(gluon.AttachQuarkBEvent);

            Assert.NotNull(gluon.QuarkA);
            Assert.NotNull(gluon.QuarkB);
            Assert.True(gluon.QuarkA.HasAttractedToAnotherObject);
            Assert.True(gluon.QuarkB.HasAttractedToAnotherObject);
        }
    }
}
