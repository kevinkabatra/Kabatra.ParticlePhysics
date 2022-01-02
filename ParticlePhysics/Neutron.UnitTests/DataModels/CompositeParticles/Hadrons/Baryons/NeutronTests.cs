﻿namespace SubatomicParticles.UnitTests.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System.Linq;
    using SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons;
    using SubatomicParticles.DataModels.ElementaryParticles;
    using Utilities;
    using Xunit;

    public class NeutronTests : SubatomicParticleTest
    {
        private Neutron _neutron;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA1816:Dispose methods should call SuppressFinalize", Justification = "This is done in the base class.")]
        public override void Dispose()
        {
            base.Dispose();

            // Remove timer when object is no longer needed, otherwise it will pollute universe
            _neutron.BetaDecayEvent.Dispose();
            _neutron = null;
        }

        [Fact]
        public void CanMakeNeutron()
        {
            _neutron = new Neutron();

            Assert.NotNull(_neutron);
            Assert.Collection(_neutron.Quarks,
                    firstQuark => Assert.Equal(Neutron.ConstantComposition.ToList()[0], firstQuark),
                    secondQuark => Assert.Equal(Neutron.ConstantComposition.ToList()[1], secondQuark),
                    thirdQuark => Assert.Equal(Neutron.ConstantComposition.ToList()[2], thirdQuark)
            );
            Assert.Equal(Baryon.ConstantGluons.Count, _neutron.Gluons.Count());
            Assert.Equal(Neutron.ConstantChargeType, _neutron.Charge);
            Assert.Equal(Neutron.ConstantChargeValue, _neutron.ChargeValue);
            Assert.Equal(Neutron.ConstantMassInKilograms, _neutron.MassInKilograms);
            Assert.Equal(Neutron.ConstantMassInElectronVolts, _neutron.MassInElectronVolts);
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
    }
}
