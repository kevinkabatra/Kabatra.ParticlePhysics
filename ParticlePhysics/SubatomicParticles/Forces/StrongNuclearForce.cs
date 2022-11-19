namespace SubatomicParticles.Forces
{
    using System.Linq;
    using System.Threading.Tasks;
    using Interfaces;
    using Interfaces.Forces;
    using SubatomicParticles.DataModels.ElementaryParticles;
    using Universe.Constants;
    using Universe.DataModels;

    public class StrongNuclearForce : IStrongNuclearForce
    {
        private Universe _universe;

        public StrongNuclearForce(Universe universe)
        {
            _universe = universe;
        }

        public Task Hadronization()
        {
            return Task.Run(() =>
            {
                if (StrongNuclearForce.CanSubatomicParticlesCombine(_universe)) return;
                
                _universe.SubatomicParticles
                    .ForEach(subatomicParticle => 
                    {
                        if(subatomicParticle.GetType() != typeof(Gluon)) return;

                        var gluon = (Gluon) subatomicParticle;
                        if(gluon.QuarkA == null || gluon.QuarkB == null) return;

                        // ToDo: Get Quarks from Gluons and see if they are connected to other Quarks to form a defined Hadron
                    });
            });
        }

        public static Task<T> Attach<T>() where T : ISubatomicParticle
        {
            return Task<T>.Run(() =>
            {
                var universe = Universe.GetOrCreateInstance();
                if (StrongNuclearForce.CanSubatomicParticlesCombine(universe)) return default;

                var subatomicParticleToAttachTo = universe.SubatomicParticles.OfType<T>().FirstOrDefault(subatomicParticle =>
                        !subatomicParticle.HasAttractedToAnotherObject
                );

                return subatomicParticleToAttachTo ?? default;
            });

        }

        ///<summary>
        ///     Prior to the end of the Quark Epoch the universe is too hot to have any subatomic particles combine, Quarks and Gluons form a Quark Gluon plasma.
        ///</summary>
        private static bool CanSubatomicParticlesCombine(Universe universe)
        {
            return universe.Epoch < Epoch.EndQuarkEpoch ? false : true;
        }
    }
}
