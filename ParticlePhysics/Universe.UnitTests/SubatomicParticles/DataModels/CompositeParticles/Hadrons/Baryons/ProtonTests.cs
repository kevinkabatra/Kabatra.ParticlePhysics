namespace Universe.UnitTests.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Universe.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons;
    using global::Universe.SubatomicParticles.DataModels.ElementaryParticles;
    using global::Universe.SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using global::Universe.SubatomicParticles.Interfaces.ElementaryParticles;
    using global::Universe.SubatomicParticles.Interfaces.ElementaryParticles.Quarks;
    using global::Universe.Universe.Utilities;
    using Universe.InversionOfControlDataModels;
    using Xunit;

    public class ProtonTests : CompositeParticleTests<Proton, ProtonCreator>
    {
        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CanMakeParticleFromQuarksAndGluons"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluons()
        {
            var proton = new Proton(Proton.ConstantComposition, Baryon.ConstantGluons);
            ValidateCreation(proton);
        }

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CanMakeParticleFromQuarksAndGluonsAndNotHaveErroneousExtraParticles"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluonsAndNotHaveErroneousExtraParticles()
        {
            var upQuarkCreator = new UpQuarkCreator();
            var downQuarkCreator = new DownQuarkCreator();
            var gluonCreator = new GluonCreator();

            // Create a universe that is isolated from the other tests and register all particle creators.
            var isolatedUniverse = (NonSingletonUniverse)UniverseUtility<NonSingletonUniverse>.GetOrCreateUniverse();
            isolatedUniverse.RegisterMatterCreationEvent(SubatomicParticleCreator);
            isolatedUniverse.RegisterMatterCreationEvent(upQuarkCreator);
            isolatedUniverse.RegisterMatterCreationEvent(downQuarkCreator);
            isolatedUniverse.RegisterMatterCreationEvent(gluonCreator);

            var quarks = new List<IQuark>
            {
                upQuarkCreator.Create(),
                upQuarkCreator.Create(),
                downQuarkCreator.Create()
            };

            var gluons = new List<IGluon>
            {
                gluonCreator.Create(),
                gluonCreator.Create()
            };

            ((ProtonCreator)SubatomicParticleCreator).Create(quarks, gluons);

            var expectedParticleCount = quarks.Count + gluons.Count + 1; // + 1 for Proton
            Assert.Equal(expectedParticleCount, isolatedUniverse.SubatomicParticles.Count);
        }

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CannotMakeParticleWithIncorrectCharge"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectCharge()
        {
            var wrongQuarks = new List<IQuark>
            {
                new UpQuarkCreator().Create(),
                new UpQuarkCreator().Create(),
                new UpQuarkCreator().Create()
            };

            Assert.Throws<Exception>(() => new Proton(wrongQuarks, Baryon.ConstantGluons));
        }

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CannotMakeParticleWithIncorrectQuarks"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectQuarks()
        {
            Assert.Throws<ArgumentException>(() => new Proton(Antiproton.ConstantComposition, Baryon.ConstantGluons));
        }

        /// <inheritdoc cref="SubatomicParticleTests{TParticle,TParticleCreator}.ValidateCreation"/>
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
