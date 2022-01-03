namespace SubatomicParticles.DataModels.ElementaryParticles.Quarks
{
    using Constants;
    using Interfaces.ElementaryParticles.Quarks;

    /// <inheritdoc cref="IQuark"/>
    public abstract class Quark : ElementaryParticle, IQuark
    {
        protected Quark(QuarkFlavor quarkFlavor, ChargeType charge, double chargeValue, double massInElectronVolts) : base(charge, chargeValue, null, massInElectronVolts)
        {
            QuarkFlavor = quarkFlavor;
        }

        public QuarkFlavor QuarkFlavor { get; }

        public override bool Equals(object objectToCompare)
        {
            if (objectToCompare is not Quark quarkToCompare) return false;

            return 
                QuarkFlavor.Equals(quarkToCompare.QuarkFlavor)
                && Charge.Equals(quarkToCompare.Charge)
                && ChargeValue.Equals(quarkToCompare.ChargeValue)
                && MassInKilograms.Equals(quarkToCompare.MassInKilograms)
                && MassInElectronVolts.Equals(quarkToCompare.MassInElectronVolts)
                && HasAttractedToAnotherObject.Equals(quarkToCompare.HasAttractedToAnotherObject);
        }

        public override int GetHashCode()
        {
            var identifier = QuarkFlavor + Charge.ToString() + ChargeValue;
            return identifier.GetHashCode();
        }
    }
}
