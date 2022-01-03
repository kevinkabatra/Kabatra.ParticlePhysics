namespace SubatomicParticles.Forces
{
    using System.Linq;
    using Interfaces;
    using Interfaces.Forces;
    using Universe.DataModels;

    public class StrongNuclearForce<T> : IStrongNuclearForce<T> where T : ISubatomicParticle
    {
        public static T Attach()
        {
            var subatomicParticleToAttachTo = Universe.GetOrCreateInstance().SubatomicParticles.OfType<T>().FirstOrDefault(subatomicParticle =>
                    !subatomicParticle.HasAttractedToAnotherObject
                );

            return subatomicParticleToAttachTo ?? default;
        }
    }
}
