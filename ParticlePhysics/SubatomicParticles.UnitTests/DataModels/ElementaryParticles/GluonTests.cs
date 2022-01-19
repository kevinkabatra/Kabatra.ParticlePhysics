namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles
{
    using System;
    using SubatomicParticles.DataModels.ElementaryParticles;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Universe.DataModels;
    using Universe.Constants;
    using Utilities;
    using Xunit;

    public class GluonTests : SubatomicParticleTests<Gluon, GluonCreator>, IDisposable
    {
        private Gluon _gluon;

        /// <summary>
        ///     Remove timer when object is no longer needed, otherwise it will pollute universe
        /// </summary>
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

        /// <inheritdoc cref="SubatomicParticleTests{TParticle,TParticleCreator}.ValidateCreation"/>
        protected override void ValidateCreation(Gluon particle)
        {
            Assert.Null(particle.QuarkA);
            Assert.Null(particle.QuarkB);
            Assert.Equal(Gluon.ConstantChargeType, particle.Charge);
            Assert.Equal(Gluon.ConstantChargeValue, particle.ChargeValue);
            Assert.Equal(Gluon.ConstantMassInKilograms, particle.MassInKilograms);
            Assert.Equal(Gluon.ConstantMassInElectronVolts, particle.MassInElectronVolts);
        }
    }
}
