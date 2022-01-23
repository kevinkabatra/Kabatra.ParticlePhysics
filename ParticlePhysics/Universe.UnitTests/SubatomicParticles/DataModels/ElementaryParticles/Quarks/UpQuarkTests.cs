namespace Universe.UnitTests.SubatomicParticles.DataModels.ElementaryParticles.Quarks
{
    using global::Universe.SubatomicParticles.Constants;
    using global::Universe.SubatomicParticles.DataModels.ElementaryParticles.Quarks;

    public class UpQuarkTests : QuarkTests<UpQuark, UpQuarkCreator>
    {
        /// <inheritdoc cref="SubatomicParticleTests{TParticle,TParticleCreator}.ValidateCreation"/>
        protected override void ValidateCreation(UpQuark particle)
        {
            ValidateQuarkCreation(particle, QuarkFlavor.Up, UpQuark.ConstantChargeType, UpQuark.ConstantChargeValue, UpQuark.ConstantMassInElectronVolts, UpQuark.ConstantAntiparticleType);
        }
    }
}
