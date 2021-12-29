namespace SubatomicParticles.UnitTests.DataModels
{
    using System;
    using SubatomicParticles.DataModels;
    using Utilities;
    using Xunit;

    public class NeutronTests : IDisposable
    {
        private Neutron _neutron;

        public void Dispose()
        {
            // Remove timer when object is no longer needed, otherwise it will pollute universe
            _neutron.BetaDecayEvent.Dispose();
            _neutron = null;

            // Reset the singleton in between tests
            Universe.DataModels.Universe.Reset();

            // Prevents Garbage Collector from wasting time
            // https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1816
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void CanMakeNeutron()
        {
            _neutron = new Neutron();

            Assert.NotNull(_neutron);
            Assert.Equal(Neutron.ConstantChargeType, _neutron.Charge);
            Assert.Equal(Neutron.ConstantMass, _neutron.Mass);
        }

        [Fact]
        public void CanDecayIntoProtonAndElectron()
        {
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();
            Assert.NotNull(universe);

            _neutron = new Neutron();
            
            // Wait for the neutron to decay
            TimerUtility.FireTimerAndWait(_neutron.BetaDecayEvent);
            
            Assert.Equal(2, universe.SubatomicParticles.Count);
        }
    }
}
