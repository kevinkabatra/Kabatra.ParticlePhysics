namespace SubatomicParticles.UnitTests.DataModels.Quarks
{
    using SubatomicParticles.DataModels.Quarks;
    using Xunit;

    public class DownQuarkTests : QuarkTests<DownQuark>
    {
        [Fact]
        public void CanCreateDownQuark()
        {
            var downQuark = new DownQuark();

            Assert.NotNull(downQuark);
            Assert.Equal(DownQuark.ConstantChargeType, downQuark.Charge);
            Assert.Equal(DownQuark.ConstantChargeValue, downQuark.ChargeValue);
            Assert.Equal(DownQuark.ConstantMassInElectronVolts, downQuark.MassInElectronVolts);
            Assert.Null(downQuark.MassInKilograms);
        }
    }
}
