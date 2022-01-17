namespace SubatomicParticles.UnitTests.DataModels.CompositeParticles.Hadrons.Mesons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces.ElementaryParticles.Quarks;
    using SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons;
    using SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons.Pions;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Xunit;

    public class PionPositiveTests : CompositeParticleTests<PionPositive>
    {
        /// <inheritdoc cref="CompositeParticleTests{T}.CanMakeParticleFromQuarksAndGluons"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluons()
        {
            var pionPositive = new PionPositive(PionPositive.ConstantComposition, Meson.ConstantGluons);
            ValidateCreation(pionPositive);
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

            Assert.Throws<Exception>(() => new PionPositive(wrongQuarks, Meson.ConstantGluons));
        }

        /// <inheritdoc cref="CompositeParticleTests{T}.CannotMakeParticleWithIncorrectQuarks"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectQuarks()
        {
            Assert.Throws<ArgumentException>(() => new PionPositive(PionNegative.ConstantComposition, Meson.ConstantGluons));
        }

        /// <inheritdoc cref="SubatomicParticleTests{T}.ValidateCreation"/>
        protected override void ValidateCreation(PionPositive particle)
        {
            var quarks = PionPositive.ConstantComposition.ToList();
            Assert.Collection(particle.Quarks,
                firstQuark => Assert.Equal(quarks[0], firstQuark),
                secondQuark => Assert.Equal(quarks[1], secondQuark)
            );

            Assert.Equal(PionPositive.ConstantAntiparticleType, particle.AntiparticleType);
            Assert.Equal(Meson.ConstantGluons.Count, particle.Gluons.Count());
            Assert.Equal(PionPositive.ConstantChargeType, particle.Charge);
            Assert.Equal(PionPositive.ConstantChargeValue, particle.ChargeValue);
            Assert.Null(particle.MassInKilograms);
            Assert.Equal(PionPositive.ConstantMassInElectronVolts, particle.MassInElectronVolts);
        }
    }
}
