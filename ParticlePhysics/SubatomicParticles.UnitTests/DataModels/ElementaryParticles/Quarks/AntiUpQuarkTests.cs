namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles.Quarks
{
    using Constants;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Xunit;

    public class AntiUpQuarkTests : QuarkTests<AntiUpQuark>
    {
        [Fact]
        public void CanCreateAntiUpQuark()
        {
            var antiUpQuark = new AntiUpQuark();
            ValidateQuarkCreation(antiUpQuark, QuarkFlavor.Up, AntiUpQuark.ConstantChargeType, AntiUpQuark.ConstantChargeValue, AntiUpQuark.ConstantMassInElectronVolts, AntiUpQuark.ConstantAntiparticleType);
        }
    }
}
