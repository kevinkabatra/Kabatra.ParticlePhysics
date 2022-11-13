namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles
{
    using System;
    using SubatomicParticles.DataModels.ElementaryParticles;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Universe.DataModels;
    using Universe.Constants;
    using Utilities;
    using Xunit;

    public class GluonTests : IDisposable
    {
        private Gluon _gluon;
        public void Dispose()
        {
            if (_gluon == null) return;
            _gluon.AttachQuarkAEvent.Dispose();
            _gluon.AttachQuarkBEvent.Dispose();
            _gluon = null;

            // Prevents Garbage Collector from wasting time
            // https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1816
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void CanCreateGluon()
        {
            _gluon = new Gluon();

            Assert.NotNull(_gluon);
            Assert.Null(_gluon.QuarkA);
            Assert.Null(_gluon.QuarkB);
            Assert.Equal(Gluon.ConstantChargeType, _gluon.Charge);
            Assert.Equal(Gluon.ConstantChargeValue, _gluon.ChargeValue);
            Assert.Equal(Gluon.ConstantMassInKilograms, _gluon.MassInKilograms);
            Assert.Equal(Gluon.ConstantMassInElectronVolts, _gluon.MassInElectronVolts);
        }

        [Fact]
        public void GluonIsAddedToUniverseUponCreation()
        {
            _gluon = new Gluon();
            var universe = Universe.GetOrCreateInstance();

            Assert.Contains(_gluon, universe.SubatomicParticles);
        }

        [Fact]
        public void CanBindToQuarks()
        {
            _ = new UpQuark();
            _ = new UpQuark();

            _gluon = new Gluon();

            Universe.GetOrCreateInstance().SetEpoch(Epoch.EndQuarkEpoch);

            TimerUtility.FireTimerAndWait(_gluon.AttachQuarkAEvent);
            TimerUtility.FireTimerAndWait(_gluon.AttachQuarkBEvent);

            Assert.NotNull(_gluon.QuarkA);
            Assert.NotNull(_gluon.QuarkB);
            Assert.True(_gluon.QuarkA.HasAttractedToAnotherObject);
            Assert.True(_gluon.QuarkB.HasAttractedToAnotherObject);
        }
    }
}
