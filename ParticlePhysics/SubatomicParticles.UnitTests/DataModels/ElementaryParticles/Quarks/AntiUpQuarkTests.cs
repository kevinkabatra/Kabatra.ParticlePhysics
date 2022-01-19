namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles.Quarks
{
    using Constants;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;

    public class AntiUpQuarkTests : QuarkTests<AntiUpQuark, AntiUpQuarkCreator>
    {
        /// <inheritdoc cref="SubatomicParticleTests{TParticle,TParticleCreator}.ValidateCreation"/>
        protected override void ValidateCreation(AntiUpQuark particle)
        {
            ValidateQuarkCreation(particle, QuarkFlavor.Up, AntiUpQuark.ConstantChargeType, AntiUpQuark.ConstantChargeValue, AntiUpQuark.ConstantMassInElectronVolts, AntiUpQuark.ConstantAntiparticleType);
        }
    }
}
