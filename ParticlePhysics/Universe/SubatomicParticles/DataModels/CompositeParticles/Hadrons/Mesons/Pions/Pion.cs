namespace Universe.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons.Pions
{
    using System;
    using System.Collections.Generic;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;

    /// <summary>
    ///     Pions are the lights mesons and, more generally, the lightest hadrons.
    /// <para>See the following article for more information:</para>
    /// <para>1. <a href="https://en.wikipedia.org/wiki/Pion">Wikipedia: Pion</a></para>
    /// </summary>
    public abstract class Pion : Meson
    {
        protected Pion(ICollection<IQuark> quarks, ICollection<IGluon> gluons, double? massInElectronVolts, Type antiparticle) : base(quarks, gluons, null, massInElectronVolts, antiparticle)
        {
        }
    }
}
