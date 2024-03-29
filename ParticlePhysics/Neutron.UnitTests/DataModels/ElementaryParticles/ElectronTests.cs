﻿namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles
{
    using SubatomicParticles.DataModels.ElementaryParticles;
    using Xunit;

    public class ElectronTests
    {
        [Fact]
        public void CanMakeElectron()
        {
            var electron = new Electron();

            Assert.NotNull(electron);
            Assert.Equal(Electron.ConstantChargeType, electron.Charge);
            Assert.Equal(Electron.ConstantMassInKilograms, electron.MassInKilograms);
        }

        [Fact]
        public void ElectronIsAddedToUniverseUponCreation()
        {
            var electron = new Electron();
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();

            Assert.Contains(electron, universe.SubatomicParticles);
        }
    }
}
