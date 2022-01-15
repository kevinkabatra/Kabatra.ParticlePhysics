namespace SubatomicParticles.Interfaces
{
    using Constants;

    /// <summary>
    ///     Any particle that is smaller than an atom.
    /// <para>See the following article for more information:</para>
    /// <para>1. <a href="https://en.wikipedia.org/wiki/Subatomic_particle">Wikipedia: Subatomic particle</a></para>
    /// </summary>
    public interface ISubatomicParticle
    {
        ChargeType Charge { get; }
        double ChargeValue { get; }
        double? MassInKilograms { get; }
        double? MassInElectronVolts { get; }
        System.Type AntiparticleType { get; }
        bool HasAttractedToAnotherObject { get; set; }
    }
}
