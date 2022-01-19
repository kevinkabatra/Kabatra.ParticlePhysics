namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles.Quarks
{
    using Constants;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;

    public class UpQuarkTests : QuarkTests<UpQuark, UpQuarkCreator>
    {
        /// <inheritdoc cref="SubatomicParticleTests{TParticle,TParticleCreator}.ValidateCreation"/>
        protected override void ValidateCreation(UpQuark particle)
        {
            ValidateQuarkCreation(particle, QuarkFlavor.Up, UpQuark.ConstantChargeType, UpQuark.ConstantChargeValue, UpQuark.ConstantMassInElectronVolts, UpQuark.ConstantAntiparticleType);
        }
    }
}
