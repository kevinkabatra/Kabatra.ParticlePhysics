namespace SubatomicParticles.UnitTests.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System.Linq;
    using SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons;
    using Xunit;

    public class AntiprotonTests : SubatomicParticleTests<Antiproton>
    {
        /// <inheritdoc cref="SubatomicParticleTests{T}.ValidateCreation"/>
        protected override void ValidateCreation(Antiproton particle)
        {
            var quarks = Antiproton.ConstantComposition.ToList();
            Assert.Collection(particle.Quarks,
                firstQuark => Assert.Equal(quarks[0], firstQuark),
                secondQuark => Assert.Equal(quarks[1], secondQuark),
                thirdQuark => Assert.Equal(quarks[2], thirdQuark)
            );

            Assert.Equal(Antiproton.ConstantAntiparticleType, particle.AntiparticleType);
            Assert.Equal(Baryon.ConstantGluons.Count, particle.Gluons.Count());
            Assert.Equal(Antiproton.ConstantChargeType, particle.Charge);
            Assert.Equal(Antiproton.ConstantChargeValue, particle.ChargeValue);
            Assert.Equal(Antiproton.ConstantMassInKilograms, particle.MassInKilograms);
            Assert.Equal(Antiproton.ConstantMassInElectronVolts, particle.MassInElectronVolts);
        }
    }
}
