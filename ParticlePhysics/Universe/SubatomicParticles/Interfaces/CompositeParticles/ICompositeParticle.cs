namespace Universe.SubatomicParticles.Interfaces.CompositeParticles
{
    using System.Collections.Generic;
    using ElementaryParticles;
    using ElementaryParticles.Quarks;

    /// <summary>
    ///     Composite particles are subatomic particles that are composed of other particles (for example: a proton, neutron, or meson).
    /// They are bound states of elementary particles.
    /// <para>See the following articles for more information:</para>
    /// <para>1. <a href="https://en.wikipedia.org/wiki/Subatomic_particle">Wikipedia: Subatomic particle</a></para>
    /// <para>2. <a href="https://en.wikipedia.org/wiki/List_of_particles#Composite_particles">Wikipedia: Composite particles</a></para>
    /// </summary>
    public interface ICompositeParticle : ISubatomicParticle
    {
        IEnumerable<IQuark> Quarks { get; }
        IEnumerable<IGluon> Gluons { get; }
    }
}