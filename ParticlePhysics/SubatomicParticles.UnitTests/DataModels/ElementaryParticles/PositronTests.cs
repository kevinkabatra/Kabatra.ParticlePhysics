namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles
{
    using SubatomicParticles.DataModels.ElementaryParticles;
    using Xunit;

    public class PositronTests : SubatomicParticleTests<Positron>
    {
        /// <inheritdoc cref="SubatomicParticleTests{T}.ValidateCreation"/>
        protected override void ValidateCreation(Positron particle)
        {
            Assert.Equal(Positron.ConstantAntiparticleType, particle.AntiparticleType);
            Assert.Equal(Positron.ConstantChargeType, particle.Charge);
            Assert.Equal(Positron.ConstantChargeValue, particle.ChargeValue);
            Assert.Equal(Positron.ConstantMassInKilograms, particle.MassInKilograms);
            Assert.Equal(Positron.ConstantMassInElectronVolts, particle.MassInElectronVolts);
        }
    }
}
