namespace Universe.UnitTests.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Universe.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons;
    using global::Universe.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons.Pions;
    using global::Universe.SubatomicParticles.DataModels.ElementaryParticles;
    using global::Universe.SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using global::Universe.SubatomicParticles.Interfaces.ElementaryParticles;
    using global::Universe.SubatomicParticles.Interfaces.ElementaryParticles.Quarks;
    using global::Universe.Universe.Utilities;
    using Universe.InversionOfControlDataModels;
    using Xunit;

    public class PionPositiveTests : CompositeParticleTests<PionPositive, PionPositiveCreator>
    {
        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CanMakeParticleFromQuarksAndGluons"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluons()
        {
            var pionPositive = new PionPositive(PionPositive.ConstantComposition, Meson.ConstantGluons);
            ValidateCreation(pionPositive);
        }

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CanMakeParticleFromQuarksAndGluonsAndNotHaveErroneousExtraParticles"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluonsAndNotHaveErroneousExtraParticles()
        {
            var upQuarkCreator = new UpQuarkCreator();
            var antiDownQuarkCreator = new AntiDownQuarkCreator();
            var gluonCreator = new GluonCreator();

            // Create a universe that is isolated from the other tests and register all particle creators.
            var isolatedUniverse = (NonSingletonUniverse)UniverseUtility<NonSingletonUniverse>.GetOrCreateUniverse();
            isolatedUniverse.RegisterMatterCreationEvent(SubatomicParticleCreator);
            isolatedUniverse.RegisterMatterCreationEvent(upQuarkCreator);
            isolatedUniverse.RegisterMatterCreationEvent(antiDownQuarkCreator);
            isolatedUniverse.RegisterMatterCreationEvent(gluonCreator);

            var quarks = new List<IQuark>
            {
                upQuarkCreator.Create(),
                antiDownQuarkCreator.Create()
            };

            var gluons = new List<IGluon>
            {
                gluonCreator.Create()
            };

            ((PionPositiveCreator)SubatomicParticleCreator).Create(quarks, gluons);

            var expectedParticleCount = quarks.Count + gluons.Count + 1; // + 1 for PionPositive
            Assert.Equal(expectedParticleCount, isolatedUniverse.SubatomicParticles.Count);
        }

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CannotMakeParticleWithIncorrectCharge"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectCharge()
        {
            var wrongQuarks = new List<IQuark>
            {
                new UpQuarkCreator().Create(),
                new UpQuarkCreator().Create()
            };

            Assert.Throws<Exception>(() => new PionPositive(wrongQuarks, Meson.ConstantGluons));
        }

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CannotMakeParticleWithIncorrectQuarks"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectQuarks()
        {
            Assert.Throws<ArgumentException>(() => new PionPositive(PionNegative.ConstantComposition, Meson.ConstantGluons));
        }

        /// <inheritdoc cref="SubatomicParticleTests{TParticle,TParticleCreator}.ValidateCreation"/>
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
