﻿namespace Universe.UnitTests.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Universe.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons;
    using global::Universe.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons.Pions;
    using global::Universe.SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using global::Universe.SubatomicParticles.Interfaces.ElementaryParticles.Quarks;
    using Xunit;

    public class PionNegativeTests : CompositeParticleTests<PionNegative, PionNegativeCreator>
    {
        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CanMakeParticleFromQuarksAndGluons"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluons()
        {
            var pionNegative = new PionNegative(PionNegative.ConstantComposition, Meson.ConstantGluons);
            ValidateCreation(pionNegative);
        }

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CannotMakeParticleWithIncorrectCharge"/>
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

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CannotMakeParticleWithIncorrectQuarks"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectQuarks()
        {
            Assert.Throws<ArgumentException>(() => new PionNegative(PionPositive.ConstantComposition, Meson.ConstantGluons));
        }

        /// <inheritdoc cref="SubatomicParticleTests{TParticle,TParticleCreator}.ValidateCreation"/>
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
