namespace SubatomicParticles.UnitTests.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;
    using SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons;
    using SubatomicParticles.DataModels.ElementaryParticles;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Universe.UnitTests.Utilities;
    using Utilities;
    using Xunit;

    public class NeutronTests : CompositeParticleTests<Neutron>, IDisposable
    {
        private Neutron _neutron;

        /// <summary>
        ///     Remove timer when object is no longer needed, otherwise it will pollute universe
        /// </summary>
        public void Dispose()
        {
            if (_neutron == null) return;
            _neutron.BetaDecayEvent.Dispose();
            _neutron = null;

            // Prevents Garbage Collector from wasting time
            // https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1816
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc cref="CompositeParticleTests{T}.CanMakeParticleFromQuarksAndGluons"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluons()
        {
            _neutron = new Neutron(Neutron.ConstantComposition, Baryon.ConstantGluons);
            ValidateCreation(_neutron);
        }

        /// <inheritdoc cref="CompositeParticleTests{T}.CanMakeParticleFromQuarksAndGluonsAndNotHaveErroneousExtraParticles"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluonsAndNotHaveErroneousExtraParticles()
        {
            var quarks = new List<IQuark>
            {
                new UpQuark(),
                new DownQuark(),
                new DownQuark()
            };

            var gluons = new List<IGluon>
            {
                new Gluon(),
                new Gluon()
            };

            // ToDo: Need to update this to GetUniverse, and then move this logic into the Universe project.
            // ToDo: The SubatomicParticle code will need to reference IUniverse when adding a particle.
            // ToDo: I think I can achieve this with GetUniverse, which will replace GetOrCreateInstance.
            // ToDo: The tests will need to create two different universes. The current singleton for normal tests, and the nonsingleton for isolated tests.
            // ToDo: The program will use Autofac to say that the Universe will use DataModels.Universe from Universe project.
            var isolatedUniverse = new UniverseUtility().GetNonSingletonUniverse();

            _neutron = new Neutron(quarks, gluons);


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

            Assert.Throws<Exception>(() => new Neutron(wrongQuarks, Baryon.ConstantGluons));
        }

        /// <inheritdoc cref="CompositeParticleTests{T}.CannotMakeParticleWithIncorrectQuarks"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectQuarks()
        {
            Assert.Throws<ArgumentException>(() => new Neutron(Antineutron.ConstantComposition, Baryon.ConstantGluons));
        }

        [Fact]
        public void CanDecayIntoProtonAndElectron()
        {
            _neutron = new Neutron();
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();
            
            // Wait for the neutron to decay
            TimerUtility.FireTimerAndWait(_neutron.BetaDecayEvent);
            
            Assert.NotEmpty(universe.SubatomicParticles.OfType<Proton>());
            Assert.NotEmpty(universe.SubatomicParticles.OfType<Electron>());
        }

        /// <inheritdoc cref="SubatomicParticleTests{T}.ValidateCreation"/>
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
