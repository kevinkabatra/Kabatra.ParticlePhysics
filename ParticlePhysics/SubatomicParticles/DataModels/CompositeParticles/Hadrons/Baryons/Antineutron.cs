namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;

    public class Antineutron : Baryon
    {
        public static readonly Type ConstantTypeOfAntiparticle = typeof(Neutron);

        public Antineutron() : base(ConstantComposition(), ConstantGluons, Neutron.ConstantMassInKilograms, Neutron.ConstantMassInElectronVolts, ConstantTypeOfAntiparticle)
        {
        }

        public Antineutron(ICollection<IQuark> quarks, ICollection<IGluon> gluons) : base(quarks, gluons, Neutron.ConstantMassInKilograms, Neutron.ConstantMassInElectronVolts, ConstantTypeOfAntiparticle)
        {
            //ToDo: add logic to validate Quarks
        }

        public static ICollection<IQuark> ConstantComposition()
        {
            return new List<IQuark>
            {
                // ToDo: create AntiUpQuark
                // ToDo: create AntiDownQuark
                // ToDo: create AntiDownQuark
            };
        }
    }
}
