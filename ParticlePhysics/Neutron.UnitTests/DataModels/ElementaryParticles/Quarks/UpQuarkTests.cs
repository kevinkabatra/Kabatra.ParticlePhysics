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
            ValidateQuarkCreation(upQuark, QuarkFlavor.Up, UpQuark.ConstantChargeType, UpQuark.ConstantChargeValue, UpQuark.ConstantMassInElectronVolts, UpQuark.ConstantAntiparticleType);
        }
    }
}
