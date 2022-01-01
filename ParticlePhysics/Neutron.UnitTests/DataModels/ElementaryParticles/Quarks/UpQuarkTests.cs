namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles.Quarks
{
    using Constants;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Xunit;

    public class UpQuarkTests : QuarkTests<UpQuark>
    {
        [Fact]
        public void CanCreateUpQuark()
        {
            var upQuark = new UpQuark();

            Assert.NotNull(upQuark);
            Assert.Equal(QuarkFlavor.Up, upQuark.QuarkFlavor);
            Assert.Equal(UpQuark.ConstantChargeType, upQuark.Charge);
            Assert.Equal(UpQuark.ConstantChargeValue, upQuark.ChargeValue);
            Assert.Equal(UpQuark.ConstantMassInElectronVolts, upQuark.MassInElectronVolts);
            Assert.Null(upQuark.MassInKilograms);
        }
    }
}
