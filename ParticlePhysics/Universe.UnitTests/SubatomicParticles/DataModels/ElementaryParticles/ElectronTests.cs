namespace Universe.UnitTests.SubatomicParticles.DataModels.ElementaryParticles
{
    using global::Universe.SubatomicParticles.DataModels.ElementaryParticles;
    using Xunit;

    public class ElectronTests : SubatomicParticleTests<Electron, ElectronCreator>
    {
        /// <inheritdoc cref="SubatomicParticleTests{TParticle,TParticleCreator}.ValidateCreation"/>
        protected override void ValidateCreation(Electron particle)
        {
            Assert.Equal(Electron.ConstantAntiparticleType, particle.AntiparticleType);
            Assert.Equal(Electron.ConstantChargeType, particle.Charge);
            Assert.Equal(Electron.ConstantChargeValue, particle.ChargeValue);
            Assert.Equal(Electron.ConstantMassInKilograms, particle.MassInKilograms);
            Assert.Equal(Electron.ConstantMassInElectronVolts, particle.MassInElectronVolts);
        }
    }
}
