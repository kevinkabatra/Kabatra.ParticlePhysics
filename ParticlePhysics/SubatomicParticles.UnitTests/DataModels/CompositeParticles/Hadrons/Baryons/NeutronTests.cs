﻿namespace SubatomicParticles.UnitTests.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces.ElementaryParticles.Quarks;
    using SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons;
    using SubatomicParticles.DataModels.ElementaryParticles;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Utilities;
    using Xunit;

    public class NeutronTests : IDisposable
    {
        private Neutron _neutron;

        public void Dispose()
        {
            // Remove timer when object is no longer needed, otherwise it will pollute universe
            if (_neutron == null) return;
            _neutron.BetaDecayEvent.Dispose();
            _neutron = null;

            // Prevents Garbage Collector from wasting time
            // https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1816
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void CanMakeNeutron()
        {
            _neutron = new Neutron();
            ValidateNeutronCreation();
        }

        [Fact]
        public void CanMakeNeutronFromQuarksAndGluons()
        {
            _neutron = new Neutron(Neutron.ConstantComposition, Baryon.ConstantGluons);
            ValidateNeutronCreation();
        }

        [Fact]
        public void CannotMakeNeutronWithIncorrectCharge()
        {
            var wrongQuarks = new List<IQuark>
            {
                new UpQuark(),
                new UpQuark(),
                new UpQuark()
            };

            Assert.Throws<Exception>(() => new Neutron(wrongQuarks, Baryon.ConstantGluons));
        }

        [Fact]
        public void CannotMakeNeutronWithIncorrectQuarks()
        {
            Assert.Throws<ArgumentException>(() => new Neutron(Proton.ConstantComposition, Baryon.ConstantGluons));
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

        [Fact]
        public void NeutronIsAddedToUniverseUponCreation()
        {
            _neutron = new Neutron();
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();

            Assert.Contains(_neutron, universe.SubatomicParticles);
        }

        private void ValidateNeutronCreation()
        {
            Assert.NotNull(_neutron);

            var quarks = Neutron.ConstantComposition.ToList();
            Assert.Collection(_neutron.Quarks,
                firstQuark => Assert.Equal(quarks[0], firstQuark),
                secondQuark => Assert.Equal(quarks[1], secondQuark),
                thirdQuark => Assert.Equal(quarks[2], thirdQuark)
            );

            Assert.Equal(Neutron.ConstantAntiparticleType, _neutron.AntiparticleType);
            Assert.Equal(Baryon.ConstantGluons.Count, _neutron.Gluons.Count());
            Assert.Equal(Neutron.ConstantChargeType, _neutron.Charge);
            Assert.Equal(Neutron.ConstantChargeValue, _neutron.ChargeValue);
            Assert.Equal(Neutron.ConstantMassInKilograms, _neutron.MassInKilograms);
            Assert.Equal(Neutron.ConstantMassInElectronVolts, _neutron.MassInElectronVolts);
        }
    }
}
