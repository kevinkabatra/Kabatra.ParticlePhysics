namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles.Quarks
{
    using Constants;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Xunit;

    public class AntiDownQuarkTests : QuarkTests<AntiDownQuark>
    {
        [Fact]
        public void CanCreateAntiDownQuark()
        {
            var antiDownQuark = new AntiDownQuark();
            ValidateQuarkCreation(antiDownQuark, QuarkFlavor.Down, AntiDownQuark.ConstantChargeType, AntiDownQuark.ConstantChargeValue, AntiDownQuark.ConstantMassInElectronVolts, AntiDownQuark.ConstantAntiparticleType);
        }
    }
}
