namespace SubatomicParticles.DataModels.ElementaryParticles.Quarks
{
    using System;
    using Constants;

    /// <summary>
    ///     The down quark or d quark (symbol: d) is the second-lightest of all quarks, a type of elementary particle,
    /// and a major constituent of matter. Together with the up quark, it forms the neutrons (one up quark, two down
    /// quarks) and protons (two up quarks, one down quark) of atomic nuclei.
    /// <para>See the following article for more information:</para>
    /// <para><a href="https://en.wikipedia.org/wiki/Down_quark">Wikipedia: Down quark</a></para>
    /// </summary>
    public class DownQuark : Quark
    {
        public const ChargeType ConstantChargeType = ChargeType.Negative;
        public const double ConstantChargeValue = - (1d/3d);
        public const double ConstantMassInElectronVolts = 4.7;
        public static readonly Type ConstantAntiparticleType = typeof(AntiDownQuark);

        public DownQuark() : base(QuarkFlavor.Down, ConstantChargeType, ConstantChargeValue, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
        }
    }
}
