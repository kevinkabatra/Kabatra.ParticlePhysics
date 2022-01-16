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
            ValidateQuarkCreation(downQuark, QuarkFlavor.Down, DownQuark.ConstantChargeType, DownQuark.ConstantChargeValue, DownQuark.ConstantMassInElectronVolts, DownQuark.ConstantAntiparticleType);
        }
    }
}
