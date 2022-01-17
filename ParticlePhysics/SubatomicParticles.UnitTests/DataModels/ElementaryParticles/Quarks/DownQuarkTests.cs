namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles.Quarks
{
    using Constants;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;

    public class DownQuarkTests : QuarkTests<DownQuark>
    {
        /// <inheritdoc cref="SubatomicParticleTests{T}.ValidateCreation"/>
        protected override void ValidateCreation(DownQuark particle)
        {
            ValidateQuarkCreation(particle, QuarkFlavor.Down, DownQuark.ConstantChargeType, DownQuark.ConstantChargeValue, DownQuark.ConstantMassInElectronVolts, DownQuark.ConstantAntiparticleType);
        }
    }
}
