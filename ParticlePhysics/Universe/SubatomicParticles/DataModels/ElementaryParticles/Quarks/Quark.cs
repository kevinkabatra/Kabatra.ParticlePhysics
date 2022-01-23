namespace Universe.SubatomicParticles.DataModels.ElementaryParticles.Quarks
{
    using System;
    using Constants;
    using Interfaces.ElementaryParticles.Quarks;

    /// <inheritdoc cref="IQuark"/>
    public abstract class Quark : ElementaryParticle, IQuark
    {
        protected Quark(QuarkFlavor quarkFlavor, ChargeType charge, double chargeValue, double massInElectronVolts, Type antiparticle) : base(charge, chargeValue, null, massInElectronVolts, antiparticle)
        {
            if (antiparticle.BaseType != typeof(Quark))
            {
                throw new ArgumentException("Antiparticle must extend Quark.");
            }

            QuarkFlavor = quarkFlavor;
        }

        public QuarkFlavor QuarkFlavor { get; }

        /// <inheritdoc cref="SubatomicParticle.Equals(object)"/>
        public override bool Equals(object objectToCompare)
        {
            if(!base.Equals(objectToCompare)) return false;
            if (objectToCompare is not Quark quarkToCompare) return false;

            return 
                QuarkFlavor.Equals(quarkToCompare.QuarkFlavor)
                && AntiparticleType == quarkToCompare.AntiparticleType;
        }

        /// <inheritdoc cref="SubatomicParticle.GetHashCode"/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
