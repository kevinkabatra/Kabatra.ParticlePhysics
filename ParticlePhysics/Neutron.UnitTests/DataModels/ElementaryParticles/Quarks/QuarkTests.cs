namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles.Quarks
{
    using System;
    using Constants;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Xunit;

    public abstract class QuarkTests<T> where T : Quark, new()
    {
        [Fact]
        public void QuarkIsAddedToUniverseUponCreation()
        {
            var quark = new T();
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();

            Assert.Contains(quark, universe.SubatomicParticles);
        }

        [Fact]
        public void CanTestEqualityOfQuarks()
        {
            var quarkA = new T();
            var quarkB = new T();

            Assert.Equal(quarkA, quarkB);
        }

        protected static void ValidateQuarkCreation(
            T quark,
            QuarkFlavor quarkFlavor,
            ChargeType chargeType,
            double chargeValue,
            double massInElectronVolts,
            Type antiparticle
        )
        {
            Assert.NotNull(quark);
            Assert.Equal(quarkFlavor, quark.QuarkFlavor);
            Assert.Equal(chargeType, quark.Charge);
            Assert.Equal(chargeValue, quark.ChargeValue);
            Assert.Equal(massInElectronVolts, quark.MassInElectronVolts);
            Assert.Null(quark.MassInKilograms);
            Assert.Equal(antiparticle, quark.AntiparticleType);
        }
    }
}
