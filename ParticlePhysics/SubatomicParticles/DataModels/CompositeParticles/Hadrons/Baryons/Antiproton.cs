namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using ElementaryParticles.Quarks;
    using Interfaces.ElementaryParticles.Quarks;

    public class Antiproton : Baryon
    {
        public static readonly Type ConstantAntiparticleType = typeof(Proton);

        public static ICollection<IQuark> ConstantComposition()
        {
            return new List<IQuark>
            {
                new AntiUpQuark(),
                new AntiDownQuark(),
                new AntiDownQuark()
            };
        }

        public Antiproton() : base(ConstantComposition(), ConstantGluons, Proton.ConstantMassInKilograms, Proton.ConstantMassInKilograms, ConstantAntiparticleType)
        {
        }
    }
}
