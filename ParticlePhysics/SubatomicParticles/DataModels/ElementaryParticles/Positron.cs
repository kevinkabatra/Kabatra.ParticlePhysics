﻿namespace SubatomicParticles.DataModels.ElementaryParticles
{
    using System;
    using Constants;

    /// <summary>
    ///     The positron or antielectron is the antiparticle or the antimatter counterpart of the electron.
    /// <para>See the following article for more information:</para>
    /// <para>1. <a href="https://en.wikipedia.org/wiki/Positron">Wikipedia: Positron</a></para>
    /// </summary>
    public class Positron : ElementaryParticle
    {
        public const ChargeType ConstantChargeType = ChargeType.Positive;
        public const double ConstantChargeValue = Electron.ConstantChargeValue * -1;
        public static readonly double ConstantMassInKilograms = Electron.ConstantMassInKilograms;
        public const double ConstantMassInElectronVolts = Electron.ConstantMassInElectronVolts;
        public static readonly Type ConstantAntiparticleType = typeof(Electron);

        public Positron() : base(ConstantChargeType, ConstantChargeValue, ConstantMassInKilograms, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
        }
    }
}