namespace SubatomicParticles.UnitTests.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System.Linq;
    using SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons;
    using Xunit;

    public class AntineutronTests : SubatomicParticleTests<Antineutron>
    {
        /// <inheritdoc cref="SubatomicParticleTests{T}.ValidateCreation"/>
        protected override void ValidateCreation(Antineutron particle)
        {
            var quarks = Antineutron.ConstantComposition.ToList();
            Assert.Collection(particle.Quarks,
                firstQuark => Assert.Equal(quarks[0], firstQuark),
                secondQuark => Assert.Equal(quarks[1], secondQuark),
                thirdQuark => Assert.Equal(quarks[2], thirdQuark)
            );

            Assert.Equal(Antineutron.ConstantAntiparticleType, particle.AntiparticleType);
            Assert.Equal(Baryon.ConstantGluons.Count, particle.Gluons.Count());
            Assert.Equal(Antineutron.ConstantChargeType, particle.Charge);
            Assert.Equal(Antineutron.ConstantChargeValue, particle.ChargeValue);
            Assert.Equal(Antineutron.ConstantMassInKilograms, particle.MassInKilograms);
            Assert.Equal(Antineutron.ConstantMassInElectronVolts, particle.MassInElectronVolts);
        }
    }
}
