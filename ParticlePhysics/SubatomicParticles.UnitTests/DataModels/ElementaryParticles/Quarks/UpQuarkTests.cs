namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles.Quarks
{
    using Constants;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;

    public class UpQuarkTests : QuarkTests<UpQuark>
    {
        /// <inheritdoc cref="SubatomicParticleTests{T}.ValidateCreation"/>
        protected override void ValidateCreation(UpQuark particle)
        {
            ValidateQuarkCreation(particle, QuarkFlavor.Up, UpQuark.ConstantChargeType, UpQuark.ConstantChargeValue, UpQuark.ConstantMassInElectronVolts, UpQuark.ConstantAntiparticleType);
        }
    }
}
