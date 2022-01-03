namespace SubatomicParticles.Interfaces.ElementaryParticles
{
    using Quarks;

    /// <summary>
    ///     A gluon is an elementary particle that acts as the exchange particle (or gauge boson) for the
    /// strong force between quarks. It is analogous to the exchange of photons in the electromagnetic
    /// force between two charged particles. They bind quarks together, forming hadrons such as protons
    /// and neutrons.
    /// <para>See the following article for more information:</para>
    /// <para><a href="https://en.wikipedia.org/wiki/Gluon">Wikipedia: Gluon</a></para>
    /// </summary>
    /// <remarks>
    ///     There are eight different types of gluon that can be made, and from Wikipedia I think that
    /// the difference is in the color of the effective state, not an observable color. Currently I do not
    /// see what the color will do the alter the state of the quarks that the gluons interact with or the
    /// composite particle that it is a part of. Therefore I am going to ignore that for now and pretend that
    /// there is only one type of gluon.
    /// </remarks>
    public interface IGluon : IElementaryParticle
    {
        IQuark QuarkA { get; set; }
        IQuark QuarkB { get; set; }
    }
}
