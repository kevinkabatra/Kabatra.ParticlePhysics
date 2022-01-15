namespace SubatomicParticles.DataModels
{
    using System;
    using Constants;
    using Interfaces;

    /// <inheritdoc cref="ISubatomicParticle"/>
    public abstract class SubatomicParticle : ISubatomicParticle
    {
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

        public ChargeType Charge { get; }
        public double ChargeValue { get; }
        public double? MassInKilograms { get; }
        public double? MassInElectronVolts { get; }
        public Type AntiparticleType { get; }
        public bool HasAttractedToAnotherObject { get; set; }
    }
}
