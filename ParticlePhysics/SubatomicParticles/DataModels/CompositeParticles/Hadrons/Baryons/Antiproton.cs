namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using ElementaryParticles.Quarks;
    using Interfaces.ElementaryParticles;
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

        public Antiproton(ICollection<IQuark> quarks, ICollection<IGluon> gluons) : base(quarks, gluons, ConstantMassInKilograms, ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
            var numberOfAntiUpQuarks = quarks.OfType<AntiUpQuark>().Count();
            var numberOfAntiDownQuarks = quarks.OfType<AntiDownQuark>().Count();

            if (numberOfAntiUpQuarks != 2 && numberOfAntiDownQuarks != 1)
            {
                throw new ArgumentException($"A Antiproton requires two (2) AntiUp Quark and one (1) AntiDown Quarks. This Antiproton contains {numberOfAntiUpQuarks} AntiUp Quarks and {numberOfAntiDownQuarks} AntiDown Quarks.");
            }
        }
    }
}
