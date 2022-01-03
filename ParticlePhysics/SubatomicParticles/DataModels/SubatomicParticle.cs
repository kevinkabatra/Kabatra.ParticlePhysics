namespace SubatomicParticles.DataModels
{
    using Constants;
    using Interfaces;

    /// <inheritdoc cref="ISubatomicParticle"/>
    public abstract class SubatomicParticle : ISubatomicParticle
    {
        protected SubatomicParticle(ChargeType charge, double chargeValue, double? massInKilograms, double? massInElectronVolts)
        {
            Charge = charge;
            ChargeValue = chargeValue;
            MassInKilograms = massInKilograms;
            MassInElectronVolts = massInElectronVolts;

            HasAttractedToAnotherObject = false;

            // Add this new particle to the Universe
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();
            universe.SubatomicParticles.Add(this);
        }

        public ChargeType Charge { get; }
        public double ChargeValue { get; }
        public double? MassInKilograms { get; }
        public double? MassInElectronVolts { get; }
        public bool HasAttractedToAnotherObject { get; set; }
    }
}
