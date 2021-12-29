namespace SubatomicParticles.Interfaces
{
    using Constants;

    public interface ISubatomicParticle
    {
        ChargeType Charge { get; }
        double Mass { get; }
    }
}
