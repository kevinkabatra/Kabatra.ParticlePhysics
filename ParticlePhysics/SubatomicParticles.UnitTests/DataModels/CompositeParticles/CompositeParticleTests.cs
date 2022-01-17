namespace SubatomicParticles.UnitTests.DataModels.CompositeParticles
{
    using SubatomicParticles.DataModels.CompositeParticles;

    public abstract class CompositeParticleTests<T> : SubatomicParticleTests<T> where T: CompositeParticle, new()
    {
        /// <summary>
        ///     All composite particles are made from Quarks and Gluons,
        /// this validates that you can specify the Quarks and Gluons. The
        /// Quarks must be of the correct flavor and quantity otherwise
        /// validation will fail.
        /// </summary>
        public abstract void CanMakeParticleFromQuarksAndGluons();

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
