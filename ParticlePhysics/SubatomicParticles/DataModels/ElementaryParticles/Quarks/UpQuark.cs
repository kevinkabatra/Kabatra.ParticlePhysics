namespace SubatomicParticles.DataModels.ElementaryParticles.Quarks
{
    using System;
    using Constants;
    using Interfaces;
    using MatterCreation;

    /// <summary>
    ///     The up quark or u quark (symbol: u) is the lightest of all quarks, a type of elementary particle,
    /// and a major constituent of matter. It, along with the down quark, forms the neutrons (one up quark,
    /// two down quarks) and protons (two up quarks, one down quark) of atomic nuclei.
    /// <para>See the following article for more information:</para>
    /// <para><a href="https://en.wikipedia.org/wiki/Up_quark">Wikipedia: Up quark</a></para>
    /// </summary>
    public class UpQuark : Quark
    {
        public const ChargeType ConstantChargeType = ChargeType.Positive;
        public const double ConstantChargeValue = 2/3d;
        public const double ConstantMassInElectronVolts = 2.2;
        public static readonly Type ConstantAntiparticleType = typeof(AntiUpQuark);

        public UpQuark() : base(QuarkFlavor.Up, ConstantChargeType, ConstantChargeValue, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
        }
    }

    /// <inheritdoc cref="SubatomicParticleCreator{T}"/>
    public class UpQuarkCreator : SubatomicParticleCreator<UpQuark>
    {
        public override ISubatomicParticle Create()
        {
            var upQuark = new UpQuark();
            TriggerMatterCreationEvent(new MatterCreationEvent(upQuark));

            return upQuark;
        }
    }
}
