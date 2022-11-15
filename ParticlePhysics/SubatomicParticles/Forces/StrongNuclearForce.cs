namespace SubatomicParticles.Forces
{
    using System.Linq;
    using System.Threading.Tasks;
    using Interfaces;
    using Interfaces.Forces;
    using Universe.Constants;
    using Universe.DataModels;

    public class StrongNuclearForce<T> : IStrongNuclearForce<T> where T : ISubatomicParticle
    {
        public static Task<T> Attach()
        {
            return Task<T>.Run(() =>{
                var universe = Universe.GetOrCreateInstance();
                // Prior to the end of the Quark Epoch the universe is too hot to have any subatomic particles combine, Quarks and Gluons form a Quark Gluon plasma.
                if (universe.Epoch < Epoch.EndQuarkEpoch) return default;

                var subatomicParticleToAttachTo = universe.SubatomicParticles.OfType<T>().FirstOrDefault(subatomicParticle =>
                        !subatomicParticle.HasAttractedToAnotherObject
                    );

                return subatomicParticleToAttachTo ?? default;
            });

        }
    }
}
