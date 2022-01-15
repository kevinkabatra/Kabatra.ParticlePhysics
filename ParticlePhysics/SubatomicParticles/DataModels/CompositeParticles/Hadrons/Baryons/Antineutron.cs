namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ElementaryParticles.Quarks;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;

    public class Antineutron : Baryon
    {
        public static readonly Type ConstantAntiparticleType = typeof(Neutron);

        public static ICollection<IQuark> ConstantComposition()
        {
            return new List<IQuark>
            {
                new AntiUpQuark(),
                new AntiDownQuark(),
                new AntiDownQuark()
            };
        }

        public Antineutron() : base(ConstantComposition(), ConstantGluons, Neutron.ConstantMassInKilograms, Neutron.ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
        }

        public Antineutron(ICollection<IQuark> quarks, ICollection<IGluon> gluons) : base(quarks, gluons, Neutron.ConstantMassInKilograms, Neutron.ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
            var numberOfAntiUpQuarks = quarks.OfType<AntiUpQuark>().Count();
            var numberOfAntiDownQuarks = quarks.OfType<AntiDownQuark>().Count();

            if (numberOfAntiUpQuarks != 1 && numberOfAntiDownQuarks != 2)
            {
                throw new ArgumentException($"A Neutron requires one (1) AntiUp Quark and two (2) AntiDown Quarks. This Neutron contains {numberOfAntiUpQuarks} Up Quarks and {numberOfAntiDownQuarks} Down Quarks.");
            }
        }
    }
}
