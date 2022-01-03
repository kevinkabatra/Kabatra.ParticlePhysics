namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons
{
    using System.Collections.Generic;
    using Interfaces.CompositeParticles.Hadrons;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;

    /// <inheritdoc cref="IHadron"/>
    public abstract class Hadron : CompositeParticle, IHadron
    {
        protected Hadron(IEnumerable<IQuark> quarks, IEnumerable<IGluon> gluons, double? massInKilograms, double? massInElectronVolts) : base(quarks, gluons, massInKilograms, massInElectronVolts)
        {
        }
    }
}
