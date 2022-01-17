﻿namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons.Pions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using ElementaryParticles.Quarks;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;

    /// <inheritdoc cref="Pion"/>
    public class PionNegative : Pion
    {
        public const ChargeType ConstantChargeType = ChargeType.Negative;
        public const double ConstantChargeValue = -1d;
        public const double ConstantMassInElectronVolts = 139.57039d;
        public static readonly Type ConstantAntiparticleType = typeof(PionPositive);

        public static readonly ICollection<IQuark> ConstantComposition = new List<IQuark>
        {
            new DownQuark(),
            new AntiUpQuark()
        };

        public PionNegative() : base(ConstantComposition, Meson.ConstantGluons, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
        }

        public PionNegative(ICollection<IQuark> quarks, ICollection<IGluon> gluons) : base(quarks, gluons, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
            var numberOfDownQuarks = quarks.OfType<DownQuark>().Count();
            var numberOfAntiUpQuarks = quarks.OfType<AntiUpQuark>().Count();

            if (numberOfDownQuarks != 1 && numberOfAntiUpQuarks != 1)
            {
                throw new ArgumentException($"A Negative Pion requires one (1) Down Quark and two (1) AntiUp Quarks. This Negative Pion contains {numberOfDownQuarks} Down Quarks and {numberOfAntiUpQuarks} AntiUp Quarks.");
            }
        }
    }
}
