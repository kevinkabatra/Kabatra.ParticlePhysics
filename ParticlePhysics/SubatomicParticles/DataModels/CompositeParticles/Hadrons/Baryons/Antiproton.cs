namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using Constants;
    using ElementaryParticles.Quarks;
    using Interfaces.ElementaryParticles.Quarks;

    public class Antiproton : Baryon
    {
        public const ChargeType ConstantChargeType = ChargeType.Negative;
        public const double ConstantChargeValue = Proton.ConstantChargeValue * -1;
        public static readonly double ConstantMassInKilograms = Proton.ConstantMassInKilograms;
        public const double ConstantMassInElectronVolts = Proton.ConstantMassInElectronVolts;
        public static readonly Type ConstantAntiparticleType = typeof(Proton);

        public static readonly ICollection<IQuark> ConstantComposition = new List<IQuark>
        {
            new AntiUpQuark(),
            new AntiUpQuark(),
            new AntiDownQuark()
        };

        public Antiproton() : base(ConstantComposition, ConstantGluons, ConstantMassInKilograms, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
        }
    }
}
