namespace SubatomicParticles.UnitTests.DataModels.Quarks
{
    using SubatomicParticles.DataModels.Quarks;
    using Xunit;

    public class UpQuarkTests : QuarkTests<UpQuark>
    {
        [Fact]
        public void CanCreateUpQuark()
        {
            var upQuark = new UpQuark();

            Assert.NotNull(upQuark);
            Assert.Equal(UpQuark.ConstantChargeType, upQuark.Charge);
            Assert.Equal(UpQuark.ConstantChargeValue, upQuark.ChargeValue);
            Assert.Equal(UpQuark.ConstantMassInElectronVolts, upQuark.MassInElectronVolts);
            Assert.Null(upQuark.MassInKilograms);
        }
    }
}
