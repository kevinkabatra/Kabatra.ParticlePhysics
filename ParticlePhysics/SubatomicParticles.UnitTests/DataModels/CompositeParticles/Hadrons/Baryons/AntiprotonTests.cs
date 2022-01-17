﻿namespace SubatomicParticles.UnitTests.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces.ElementaryParticles.Quarks;
    using SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Xunit;

    public class AntiprotonTests : CompositeParticleTests<Antiproton>
    {
        /// <inheritdoc cref="CompositeParticleTests{T}.CanMakeParticleFromQuarksAndGluons"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluons()
        {
            var antineutron = new Antiproton(Antiproton.ConstantComposition, Baryon.ConstantGluons);
            ValidateCreation(antineutron);
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

            Assert.Throws<Exception>(() => new Antiproton(wrongQuarks, Baryon.ConstantGluons));
        }

        /// <inheritdoc cref="CompositeParticleTests{T}.CannotMakeParticleWithIncorrectQuarks"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectQuarks()
        {
            Assert.Throws<ArgumentException>(() => new Antiproton(Proton.ConstantComposition, Baryon.ConstantGluons));
        }

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