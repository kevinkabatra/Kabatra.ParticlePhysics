namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons
{
    using System.Collections.Generic;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;

    public class Meson : Hadron
    {
        public Meson(IEnumerable<IQuark> quarks, IEnumerable<IGluon> gluons, double? massInKilograms, double? massInElectronVolts) : base(quarks, gluons, massInKilograms, massInElectronVolts)
        {
        }
    }
}
