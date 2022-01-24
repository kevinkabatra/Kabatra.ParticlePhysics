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

    public class AntineutronTests : CompositeParticleTests<Antineutron, AntineutronCreator>
    {
        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CanMakeParticleFromQuarksAndGluons"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluons()
        {
            var antineutron = new Antineutron(Antineutron.ConstantComposition, Baryon.ConstantGluons);
            ValidateCreation(antineutron);
        }

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CanMakeParticleFromQuarksAndGluonsAndNotHaveErroneousExtraParticles"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluonsAndNotHaveErroneousExtraParticles()
        {
            var antiUpQuarkCreator = new AntiUpQuarkCreator();
            var antiDownQuarkCreator = new AntiDownQuarkCreator();
            var gluonCreator = new GluonCreator();
            
            // Create a universe that is isolated from the other tests and register all particle creators.
            var isolatedUniverse = (NonSingletonUniverse)UniverseUtility<NonSingletonUniverse>.GetOrCreateUniverse();
            isolatedUniverse.RegisterMatterCreationEvent(SubatomicParticleCreator);
            isolatedUniverse.RegisterMatterCreationEvent(antiUpQuarkCreator);
            isolatedUniverse.RegisterMatterCreationEvent(antiDownQuarkCreator);
            isolatedUniverse.RegisterMatterCreationEvent(gluonCreator);
            
            var quarks = new List<IQuark>
            {
                antiUpQuarkCreator.Create(),
                antiDownQuarkCreator.Create(),
                antiDownQuarkCreator.Create()
            };

            var gluons = new List<IGluon>
            {
                gluonCreator.Create(),
                gluonCreator.Create()
            };

            ((AntineutronCreator)SubatomicParticleCreator).Create(quarks, gluons);

            var expectedParticleCount = quarks.Count + gluons.Count + 1; // + 1 for Antineutron
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

            Assert.Throws<Exception>(() => new Antineutron(wrongQuarks, Baryon.ConstantGluons));
        }

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CannotMakeParticleWithIncorrectQuarks"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectQuarks()
        {
            Assert.Throws<ArgumentException>(() => new Antineutron(Neutron.ConstantComposition, Baryon.ConstantGluons));
        }

        /// <inheritdoc cref="SubatomicParticleTests{TParticle,TParticleCreator}.ValidateCreation"/>
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
