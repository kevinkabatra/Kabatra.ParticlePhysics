namespace SubatomicParticles.UnitTests.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces.ElementaryParticles.Quarks;
    using SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Xunit;

    public class ProtonTests : CompositeParticleTests<Proton>
    {
        /// <inheritdoc cref="CompositeParticleTests{T}.CanMakeParticleFromQuarksAndGluons"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluons()
        {
            var proton = new Proton(Proton.ConstantComposition, Baryon.ConstantGluons);
            ValidateCreation(proton);
        }

        /// <inheritdoc cref="CompositeParticleTests{T}.CannotMakeParticleWithIncorrectCharge"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectCharge()
        {
            var wrongQuarks = new List<IQuark>
            {
                new UpQuark(),
                new UpQuark(),
                new UpQuark()
            };

            Assert.Throws<Exception>(() => new Proton(wrongQuarks, Baryon.ConstantGluons));
        }

        /// <inheritdoc cref="CompositeParticleTests{T}.CannotMakeParticleWithIncorrectQuarks"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectQuarks()
        {
            Assert.Throws<ArgumentException>(() => new Proton(Neutron.ConstantComposition, Baryon.ConstantGluons));
        }

        /// <inheritdoc cref="SubatomicParticleTests{T}.ValidateCreation"/>
        protected override void ValidateCreation(Proton particle)
        {
            var quarks = Proton.ConstantComposition.ToList();
            Assert.Collection(particle.Quarks,
                firstQuark => Assert.Equal(quarks[0], firstQuark),
                secondQuark => Assert.Equal(quarks[1], secondQuark),
                thirdQuark => Assert.Equal(quarks[2], thirdQuark)
            );

            Assert.Equal(Proton.ConstantAntiparticleType, particle.AntiparticleType);
            Assert.Equal(Baryon.ConstantGluons.Count, particle.Gluons.Count());
            Assert.Equal(Proton.ConstantChargeType, particle.Charge);
            Assert.Equal(Proton.ConstantChargeValue, particle.ChargeValue);
            Assert.Equal(Proton.ConstantMassInKilograms, particle.MassInKilograms);
            Assert.Equal(Proton.ConstantMassInElectronVolts, particle.MassInElectronVolts);
        }
    }
}
