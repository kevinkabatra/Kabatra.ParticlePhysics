namespace SubatomicParticles.Interfaces.CompositeParticles.Hadrons
{
    using System.Collections.Generic;
    using ElementaryParticles.Quarks;

    /// <summary>
    ///     A hadron is a composite subatomic particle made of two or more quarks held together by the strong interaction.
    ///  Hadrons are either:
    /// <para>1. Composite fermions(especially 3 quarks), in which case they are called baryons.</para>
    /// <para>2. Composite bosons (especially 2 quarks), in which case they are called mesons.</para>
    /// <para>See the following articles for more information:</para>
    /// <para><a href="https://en.wikipedia.org/wiki/Hadron">Wikipedia: Hadron</a></para>
    /// <para><a href="https://en.wikipedia.org/wiki/List_of_particles#Composite_particles">Wikipedia: List of particles</a></para>
    /// </summary>
    public interface IHadron : ICompositeParticle
    {
        IEnumerable<IQuark> Quarks { get; }
    }
}
