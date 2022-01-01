namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles.Quarks
{
    using Constants;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Xunit;

    public class DownQuarkTests : QuarkTests<DownQuark>
    {
        [Fact]
        public void CanCreateDownQuark()
        {
            var downQuark = new DownQuark();

            Assert.NotNull(downQuark);
            Assert.Equal(QuarkFlavor.Down, downQuark.QuarkFlavor);
            Assert.Equal(DownQuark.ConstantChargeType, downQuark.Charge);
            Assert.Equal(DownQuark.ConstantChargeValue, downQuark.ChargeValue);
            Assert.Equal(DownQuark.ConstantMassInElectronVolts, downQuark.MassInElectronVolts);
            Assert.Null(downQuark.MassInKilograms);
        }
    }
}
