namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles.Quarks
{
    using System;
    using Constants;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Xunit;

    public abstract class QuarkTests<T> : SubatomicParticleTests<T> where T : Quark, new()
    {
        /// <summary>
        ///     Validates that a given Quark has been created correctly.
        /// </summary>
        /// <param name="quark">The Quark to test.</param>
        /// <param name="quarkFlavor">The Flavor of the Quark. Up, Down, Strange, Charm, Top, or Bottom.</param>
        /// <param name="chargeType">Negative, Neutral, or Positive.</param>
        /// <param name="chargeValue">The numerical value of the Quark's charge. -2/3, -1/3, 1/3, or 2/3.</param>
        /// <param name="massInElectronVolts">The mass of the Quark.</param>
        /// <param name="antiparticle">The antiparticle of the Quark.</param>
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
