namespace Universe.UnitTests.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Universe.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons;
    using global::Universe.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons;
    using global::Universe.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons.Pions;
    using global::Universe.SubatomicParticles.DataModels.ElementaryParticles;
    using global::Universe.SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using global::Universe.SubatomicParticles.Interfaces.ElementaryParticles;
    using global::Universe.SubatomicParticles.Interfaces.ElementaryParticles.Quarks;
    using global::Universe.Universe.Utilities;
    using Universe.InversionOfControlDataModels;
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

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CanMakeParticleFromQuarksAndGluonsAndNotHaveErroneousExtraParticles"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluonsAndNotHaveErroneousExtraParticles()
        {
            var downQuarkCreator = new DownQuarkCreator();
            var antiUpQuarkCreator = new AntiUpQuarkCreator();
            var gluonCreator = new GluonCreator();

            // Create a universe that is isolated from the other tests and register all particle creators.
            var isolatedUniverse = (NonSingletonUniverse)UniverseUtility<NonSingletonUniverse>.GetOrCreateUniverse();
            isolatedUniverse.RegisterMatterCreationEvent(SubatomicParticleCreator);
            isolatedUniverse.RegisterMatterCreationEvent(downQuarkCreator);
            isolatedUniverse.RegisterMatterCreationEvent(antiUpQuarkCreator);
            isolatedUniverse.RegisterMatterCreationEvent(gluonCreator);

            var quarks = new List<IQuark>
            {
                downQuarkCreator.Create(),
                antiUpQuarkCreator.Create()
            };

            var gluons = new List<IGluon>
            {
                gluonCreator.Create()
            };

            ((PionNegativeCreator)SubatomicParticleCreator).Create(quarks, gluons);

            var expectedParticleCount = quarks.Count + gluons.Count + 1; // + 1 for PionNegative
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
