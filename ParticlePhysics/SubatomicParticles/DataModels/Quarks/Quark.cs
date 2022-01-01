namespace SubatomicParticles.DataModels.Quarks
{
    using Constants;
    using Interfaces;

    /// <inheritdoc cref="IQuark"/>
    public abstract class Quark : ElementaryParticle, IQuark
    {
        protected Quark(QuarkFlavor quarkFlavor, ChargeType charge, double chargeValue, double massInElectronVolts) : base(charge, chargeValue, null, massInElectronVolts)
        {
            QuarkFlavor = quarkFlavor;
        }

        public QuarkFlavor QuarkFlavor { get; }
    }
}
