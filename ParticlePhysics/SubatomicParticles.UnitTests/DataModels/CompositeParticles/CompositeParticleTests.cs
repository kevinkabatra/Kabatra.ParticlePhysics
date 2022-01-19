namespace SubatomicParticles.UnitTests.DataModels.CompositeParticles
{
    using SubatomicParticles.DataModels.CompositeParticles;

    public abstract class CompositeParticleTests<TParticle, TParticleCreator> : SubatomicParticleTests<TParticle, TParticleCreator> where TParticle: CompositeParticle, new() where TParticleCreator : CompositeParticleCreator<TParticle>, new()
    {
        /// <summary>
        ///     All composite particles are made from Quarks and Gluons,
        /// this validates that you can specify the Quarks and Gluons. The
        /// Quarks must be of the correct flavor and quantity otherwise
        /// validation will fail.
        /// </summary>
        public abstract void CanMakeParticleFromQuarksAndGluons();

        /// <summary>
        ///     When a class that contains static fields is first initialized it will
        /// initialize the static fields as well. This feature introduces an issue where
        /// particles will be added to the universe prior to calling the static field.
        /// This was actually fixed previously in commit: de15319de5071ae2a741f156b7f0ac43a5572f58,
        /// which I seemed to have forgotten and reintroduced the same issue once again, this
        /// test will prevent this issue from appearing on any composite particle data models
        /// in the future.
        ///
        ///     Also, and I only realized this last night while thinking about this, using
        /// static fields is sort of dumb, because we would be getting back the same
        /// Quarks and Gluons each time the field is accessed versus getting new Quarks
        /// and Gluons each time. So in theory you could use the same Quarks and Gluons
        /// to make an infinite number of composite particles.
        /// </summary>
        //ToDo: implement
        //public abstract void CanMakeParticleFromQuarksAndGluonsAndNotHaveErroneousExtraParticles();

        /// <summary>
        ///     All composite particles have a charge of -1, 0, or 1, this
        /// validates that a particle will fail to create if you provide a
        /// list of Quarks whose charge does not equal one of those values.
        /// </summary>
        public abstract void CannotMakeParticleWithIncorrectCharge();

        /// <summary>
        ///     All composite particles are made from specific Quarks and Gluons,
        /// this validates that a particle will fail to create if you provide a
        /// list of Quarks or Gluons that does not match the expected composition.
        /// </summary>
        public abstract void CannotMakeParticleWithIncorrectQuarks();

        
    }
}
