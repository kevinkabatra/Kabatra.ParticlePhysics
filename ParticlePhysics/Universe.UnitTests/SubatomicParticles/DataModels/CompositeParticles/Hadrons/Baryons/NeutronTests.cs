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
    using global::Universe.Universe.DataModels;
    using global::Universe.Universe.Utilities;
    using Universe.InversionOfControlDataModels;
    using Utilities;
    using Xunit;

    public class NeutronTests : CompositeParticleTests<Neutron ,NeutronCreator>, IDisposable
    {
        private Neutron _neutron;

        /// <summary>
        ///     Remove timer when object is no longer needed, otherwise it will pollute universe
        /// </summary>
        public void Dispose()
        {
            if (_neutron == null) return;
            _neutron.BetaDecayEventTimer.Dispose();
            _neutron = null;

            // Prevents Garbage Collector from wasting time
            // https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1816
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CanMakeParticleFromQuarksAndGluons"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluons()
        {
            _neutron = new Neutron(Neutron.ConstantComposition, Baryon.ConstantGluons);
            ValidateCreation(_neutron);
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
                downQuarkCreator.Create(),
                downQuarkCreator.Create()
            };

            var gluons = new List<IGluon>
            {
                gluonCreator.Create(),
                gluonCreator.Create()
            };

            _neutron = ((NeutronCreator) SubatomicParticleCreator).Create(quarks, gluons);

            var expectedParticleCount = quarks.Count + gluons.Count + 1; // + 1 for Neutron
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

            Assert.Throws<Exception>(() => new Neutron(wrongQuarks, Baryon.ConstantGluons));
        }

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CannotMakeParticleWithIncorrectQuarks"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectQuarks()
        {
            Assert.Throws<ArgumentException>(() => new Neutron(Antineutron.ConstantComposition, Baryon.ConstantGluons));
        }

        [Fact]
        public void CanDecayIntoProtonAndElectron()
        {
            //ToDo: test is currently failing
            //ToDo: this needs to be an isolated test, so that I can make sure that I find the right particles after decay
            //ToDo: test that no Neutrons exist
            //ToDo: Currently cannot find Protons and Electrons because the Universe is not listening to their creation, 
            //ToDo: also not listening to the Quarks and Gluons that make up the Neutron
            //ToDo: Assert is happening prior to the event logic triggering, events are synchronous so I just need to run prior to Assert and it will work
            
            _neutron = (Neutron) SubatomicParticleCreator.Create();
            var universe = Universe.GetOrCreateInstance();
            
            // Wait for the neutron to decay
            TimerUtility.FireTimerAndWait(_neutron.BetaDecayEventTimer);
            
            Assert.NotEmpty(universe.SubatomicParticles.OfType<Proton>());
            Assert.NotEmpty(universe.SubatomicParticles.OfType<Electron>());
        }

        /// <inheritdoc cref="SubatomicParticleTests{TParticle,TParticleCreator}.ValidateCreation"/>
        protected override void ValidateCreation(Neutron particle)
        {
            // Set this so that dispose can clean up at the end.
            _neutron = particle;

            var quarks = Neutron.ConstantComposition.ToList();
            Assert.Collection(particle.Quarks,
                firstQuark => Assert.Equal(quarks[0], firstQuark),
                secondQuark => Assert.Equal(quarks[1], secondQuark),
                thirdQuark => Assert.Equal(quarks[2], thirdQuark)
            );

            Assert.Equal(Neutron.ConstantAntiparticleType, particle.AntiparticleType);
            Assert.Equal(Baryon.ConstantGluons.Count, particle.Gluons.Count());
            Assert.Equal(Neutron.ConstantChargeType, particle.Charge);
            Assert.Equal(Neutron.ConstantChargeValue, particle.ChargeValue);
            Assert.Equal(Neutron.ConstantMassInKilograms, particle.MassInKilograms);
            Assert.Equal(Neutron.ConstantMassInElectronVolts, particle.MassInElectronVolts);
        }
    }
}
