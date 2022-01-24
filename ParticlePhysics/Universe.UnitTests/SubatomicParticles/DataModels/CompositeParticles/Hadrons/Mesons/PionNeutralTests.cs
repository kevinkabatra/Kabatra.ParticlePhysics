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

    public class PionNeutralTests : CompositeParticleTests<PionNeutral, PionNeutralCreator>
    {
        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CanMakeParticleFromQuarksAndGluons"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluons()
        {
            var pionNeutralUp = new PionNeutral(PionNeutral.ConstantCompositionUpQuarks, Meson.ConstantGluons);
            var pionNeutralDown = new PionNeutral(PionNeutral.ConstantCompositionDownQuarks, Meson.ConstantGluons);
            
            ValidateCreation(pionNeutralUp);
            ValidateCreation(pionNeutralDown);
        }

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CanMakeParticleFromQuarksAndGluonsAndNotHaveErroneousExtraParticles"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluonsAndNotHaveErroneousExtraParticles()
        {
            var pionNeutralUpCreator = new PionNeutralCreator();
            var pionNeutralDownCreator = new PionNeutralCreator();
            var upQuarkCreator = new UpQuarkCreator();
            var antiUpQuarkCreator = new AntiUpQuarkCreator();
            var downQuarkCreator = new DownQuarkCreator();
            var antiDownQuarkCreator = new AntiDownQuarkCreator();
            var gluonCreator = new GluonCreator();

            // Create two universes that are isolated from the other tests and register all particle creators.
            var isolatedUpUniverse = (NonSingletonUniverse)UniverseUtility<NonSingletonUniverse>.GetOrCreateUniverse();
            isolatedUpUniverse.RegisterMatterCreationEvent(pionNeutralUpCreator);
            isolatedUpUniverse.RegisterMatterCreationEvent(upQuarkCreator);
            isolatedUpUniverse.RegisterMatterCreationEvent(antiUpQuarkCreator);
            isolatedUpUniverse.RegisterMatterCreationEvent(gluonCreator);

            var isolatedDownUniverse = (NonSingletonUniverse)UniverseUtility<NonSingletonUniverse>.GetOrCreateUniverse();
            isolatedDownUniverse.RegisterMatterCreationEvent(pionNeutralDownCreator);
            isolatedDownUniverse.RegisterMatterCreationEvent(downQuarkCreator);
            isolatedDownUniverse.RegisterMatterCreationEvent(antiDownQuarkCreator);
            isolatedDownUniverse.RegisterMatterCreationEvent(gluonCreator);

            var upQuarks = new List<IQuark>
            {
                upQuarkCreator.Create(),
                antiUpQuarkCreator.Create()
            };

            var downQuarks = new List<IQuark>
            {
                downQuarkCreator.Create(),
                antiDownQuarkCreator.Create()
            };

            var gluons = new List<IGluon>
            {
                gluonCreator.Create()
            };


            pionNeutralUpCreator.Create(upQuarks, gluons);
            pionNeutralDownCreator.Create(downQuarks, gluons);

            var expectedUpParticleCount = upQuarks.Count + gluons.Count + 1; // + 1 for PionNeutral
            var expectedDownParticleCount = downQuarks.Count + gluons.Count + 1; // + 1 for PionNeutral

            Assert.Equal(expectedUpParticleCount, isolatedUpUniverse.SubatomicParticles.Count);
            Assert.Equal(expectedDownParticleCount, isolatedDownUniverse.SubatomicParticles.Count);
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

            Assert.Throws<Exception>(() => new PionNeutral(wrongQuarks, Meson.ConstantGluons));
        }

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CannotMakeParticleWithIncorrectQuarks"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectQuarks()
        {
            Assert.Throws<ArgumentException>(() => new PionNeutral(PionNegative.ConstantComposition, Meson.ConstantGluons));
        }

        /// <inheritdoc cref="SubatomicParticleTests{TParticle,TParticleCreator}.ValidateCreation"/>
        protected override void ValidateCreation(PionNeutral particle)
        {
            Assert.True(ValidateComposition(particle));
            Assert.Equal(PionNeutral.ConstantAntiparticleType, particle.AntiparticleType);
            Assert.Equal(Meson.ConstantGluons.Count, particle.Gluons.Count());
            Assert.Equal(PionNeutral.ConstantChargeType, particle.Charge);
            Assert.Equal(PionNeutral.ConstantChargeValue, particle.ChargeValue);
            Assert.Null(particle.MassInKilograms);
            Assert.Equal(PionNeutral.ConstantMassInElectronVolts, particle.MassInElectronVolts);
        }

        private static bool ValidateComposition(PionNeutral particle)
        {
            var upQuarks = PionNeutral.ConstantCompositionUpQuarks.ToList();
            var downQuarks = PionNeutral.ConstantCompositionDownQuarks.ToList();

            return particle.Quarks.Contains(upQuarks[0]) && particle.Quarks.Contains(upQuarks[1]) ||
                   particle.Quarks.Contains(downQuarks[0]) && particle.Quarks.Contains(downQuarks[1]);
        }
    }
}
