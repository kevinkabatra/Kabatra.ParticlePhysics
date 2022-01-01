namespace SubatomicParticles.Interfaces
{
    using Constants;

    /// <summary>
    ///     A quark is a type of elementary particle and a fundamental constituent of matter. Quarks combine to form
    /// composite particles called hadrons, the most stable of which are protons and neutrons, the components of
    /// atomic nuclei. All commonly observable matter is composed of up quarks, down quarks and electrons.
    /// <para>See the following article for more information:</para>
    /// <para><a href="https://en.wikipedia.org/wiki/Quark">Wikipedia: Quark</a></para>
    /// </summary>
    public interface IQuark : IElementaryParticle
    {
        QuarkFlavor QuarkFlavor { get; }
    }
}
