namespace Neutron.DataModels
{
    using System;
    using SubatomicParticles.Constants;
    using SubatomicParticles.DataModels;

    public class Neutron : CompositeParticle
    {
        public const ChargeType NeutronConstantChargeType = ChargeType.Neutral;
        public static readonly double NeutronConstantMass = 1.67492749804 * Math.Pow(10, -27);

        public Neutron() : base(NeutronConstantChargeType, NeutronConstantMass)
        {
        }
    }
}
