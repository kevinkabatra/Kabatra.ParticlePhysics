namespace SubatomicParticles.DataModels
{
    using System;
    using Constants;

    /// <summary>
    ///     The electron is a subatomic particle which has a negative electric charge.
    /// <para>See the following article for more information:</para>
    /// <para>1. <a href="https://en.wikipedia.org/wiki/Electron">Wikipedia: Electron</a></para>
    /// </summary>
    public class Electron : ElementaryParticle
    {
        public const ChargeType ConstantChargeType = ChargeType.Negative;
        public static readonly double ConstantMass = 9.1093837015 * Math.Pow(10, -31);

        public Electron() : base(ConstantChargeType, ConstantMass)
        {
        }
    }
}
