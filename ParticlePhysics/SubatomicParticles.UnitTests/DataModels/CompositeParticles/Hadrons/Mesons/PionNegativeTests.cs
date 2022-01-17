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

    public class PionNegativeTests : CompositeParticleTests<PionNegative>
    {
        /// <inheritdoc cref="CompositeParticleTests{T}.CanMakeParticleFromQuarksAndGluons"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluons()
        {
            var proton = new PionNegative(PionNegative.ConstantComposition, Meson.ConstantGluons);
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

            Assert.Throws<Exception>(() => new PionNegative(wrongQuarks, Meson.ConstantGluons));
        }

        /// <inheritdoc cref="CompositeParticleTests{T}.CannotMakeParticleWithIncorrectQuarks"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectQuarks()
        {
            Assert.Throws<ArgumentException>(() => new PionNegative(PionPositive.ConstantComposition, Meson.ConstantGluons));
        }

        /// <inheritdoc cref="SubatomicParticleTests{T}.ValidateCreation"/>
        protected override void ValidateCreation(PionNegative particle)
        {
            var quarks = PionNegative.ConstantComposition.ToList();
            Assert.Collection(particle.Quarks,
                firstQuark => Assert.Equal(quarks[0], firstQuark),
                secondQuark => Assert.Equal(quarks[1], secondQuark)
            );

            Assert.Equal(PionNegative.ConstantAntiparticleType, particle.AntiparticleType);
            Assert.Equal(Meson.ConstantGluons.Count, particle.Gluons.Count());
            Assert.Equal(PionNegative.ConstantChargeType, particle.Charge);
            Assert.Equal(PionNegative.ConstantChargeValue, particle.ChargeValue);
            Assert.Null(particle.MassInKilograms);
            Assert.Equal(PionNegative.ConstantMassInElectronVolts, particle.MassInElectronVolts);
        }
    }
}
