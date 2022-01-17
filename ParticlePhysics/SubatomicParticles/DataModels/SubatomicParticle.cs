namespace SubatomicParticles.DataModels
{
    using System;
    using Constants;
    using Interfaces;

    /// <inheritdoc cref="ISubatomicParticle"/>
    public abstract class SubatomicParticle : ISubatomicParticle
    {
        public ChargeType Charge { get; }
        public double ChargeValue { get; }
        public double? MassInKilograms { get; }
        public double? MassInElectronVolts { get; }
        public Type AntiparticleType { get; }
        public bool HasAttractedToAnotherObject { get; set; }

        protected SubatomicParticle(ChargeType charge, double chargeValue, double? massInKilograms, double? massInElectronVolts, Type typeOfAntiparticle)
        {
            Charge = charge;
            ChargeValue = chargeValue;
            MassInKilograms = massInKilograms;
            MassInElectronVolts = massInElectronVolts;
            AntiparticleType = typeOfAntiparticle;
            HasAttractedToAnotherObject = false;

            // Add this new particle to the Universe
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();
            universe.SubatomicParticles.Add(this);
        }

        /// <summary>
        ///     Equality checker.
        /// </summary>
        /// <param name="objectToCompare">Another subatomic particle.</param>
        /// <returns></returns>
        public override bool Equals(object objectToCompare)
        {
            if (objectToCompare is not SubatomicParticle subatomicParticle) return false;

            return
                Charge.Equals(subatomicParticle.Charge)
                && ChargeValue.Equals(subatomicParticle.ChargeValue)
                && MassInKilograms.Equals(subatomicParticle.MassInKilograms)
                && MassInElectronVolts.Equals(subatomicParticle.MassInElectronVolts)
                && HasAttractedToAnotherObject.Equals(subatomicParticle.HasAttractedToAnotherObject);
        }

        /// <summary>
        ///     Need to override GetHashCode when you override Equals, only useful for Hashes.
        /// </summary>
        /// <remarks>
        ///     All derived classes must override this as well, otherwise the compiler will complain.
        /// The derived classes will only return the base implementation.
        /// </remarks>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (typeof(SubatomicParticle) + Charge.ToString() + ChargeValue + MassInKilograms + MassInElectronVolts).GetHashCode();
        }
    }
}
