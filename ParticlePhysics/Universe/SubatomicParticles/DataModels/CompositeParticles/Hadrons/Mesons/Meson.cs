namespace Universe.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons
{
    using System;
    using System.Collections.Generic;
    using ElementaryParticles;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;

    public class Meson : Hadron
    {
        public static readonly ICollection<IGluon> ConstantGluons = new List<IGluon>
        {
            new Gluon(),
        };

        public Meson(ICollection<IQuark> quarks, ICollection<IGluon> gluons, double? massInKilograms, double? massInElectronVolts, Type antiparticle) : base(quarks, gluons, massInKilograms, massInElectronVolts, antiparticle)
        {
            if (quarks.Count != 2)
            {
                throw new ArgumentException("Mesons can only contain two (2) quarks.");
            }

            if (gluons.Count != 1)
            {
                throw new ArgumentException("Mesons can only contain one (1) gluon to bind its two (2) quarks.");
            }
        }
    }
}
