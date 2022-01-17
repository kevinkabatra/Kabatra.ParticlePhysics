namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles
{
    using SubatomicParticles.DataModels.ElementaryParticles;
    using Xunit;

    public class ElectronTests : SubatomicParticleTests<Electron>
    {
        /// <inheritdoc cref="SubatomicParticleTests{T}.ValidateCreation"/>
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
