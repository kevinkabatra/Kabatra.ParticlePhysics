namespace Universe.UnitTests.SubatomicParticles.DataModels.ElementaryParticles.Quarks
{
    using global::Universe.SubatomicParticles.Constants;
    using global::Universe.SubatomicParticles.DataModels.ElementaryParticles.Quarks;

    public class DownQuarkTests : QuarkTests<DownQuark, DownQuarkCreator>
    {
        /// <inheritdoc cref="SubatomicParticleTests{TParticle,TParticleCreator}.ValidateCreation"/>
        protected override void ValidateCreation(DownQuark particle)
        {
            ValidateQuarkCreation(particle, QuarkFlavor.Down, DownQuark.ConstantChargeType, DownQuark.ConstantChargeValue, DownQuark.ConstantMassInElectronVolts, DownQuark.ConstantAntiparticleType);
        }
    }
}
