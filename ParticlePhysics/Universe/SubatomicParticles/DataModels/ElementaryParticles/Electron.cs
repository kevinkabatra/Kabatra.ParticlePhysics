namespace Universe.SubatomicParticles.DataModels.ElementaryParticles
{
    using System;
    using Constants;
    using MatterCreation;

    /// <summary>
    ///     The electron is a subatomic particle which has a negative electric charge.
    /// <para>See the following article for more information:</para>
    /// <para>1. <a href="https://en.wikipedia.org/wiki/Electron">Wikipedia: Electron</a></para>
    /// </summary>
    public class Electron : ElementaryParticle
    {
        public const ChargeType ConstantChargeType = ChargeType.Negative;
        public const double ConstantChargeValue = -1d;
        public static readonly double ConstantMassInKilograms = 9.1093837015 * Math.Pow(10, -31);
        public const double ConstantMassInElectronVolts = 0.51099895000;
        public static readonly Type ConstantAntiparticleType = typeof(Positron);

        public Electron() : base(ConstantChargeType, ConstantChargeValue, ConstantMassInKilograms, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
        }
    }

    /// <inheritdoc cref="SubatomicParticleCreator{T}"/>
    public class ElectronCreator : SubatomicParticleCreator<Electron>
    {
        /// <inheritdoc cref="SubatomicParticleCreator{T}.Create"/>
        public override Electron Create()
        {
            var electron = new Electron();
            TriggerMatterCreationEvent(new MatterCreationEvent(electron));

            return electron;
        }
    }
}
