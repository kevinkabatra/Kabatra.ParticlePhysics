namespace SubatomicParticles.DataModels
{
    using System;
    using Constants;

    /// <summary>
    ///     The proton is a subatomic particle which has a positive electric charge and a mass slightly less than that of a neutron.
    /// <para>See the following article for more information:</para>
    /// <para>1. <a href="https://en.wikipedia.org/wiki/Proton">Wikipedia: Proton</a></para>
    /// </summary>
    public class Proton : CompositeParticle
    {
        public const ChargeType ConstantChargeType = ChargeType.Positive;
        public const double ConstantChargeValue = 1d;
        public static readonly double ConstantMassInKilograms = 1.67262192369 * Math.Pow(10, -27);
        public const double ConstantMassInElectronVolts = 938.27208816;

        public Proton() : base(ConstantChargeType, ConstantChargeValue, ConstantMassInKilograms, ConstantMassInElectronVolts)
        {
        }
    }
}
