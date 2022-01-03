namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using ElementaryParticles;
    using Interfaces.CompositeParticles.Hadrons.Baryons;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;

    /// <inheritdoc cref="IBaryon"/>
    public abstract class Baryon : Hadron, IBaryon
    {
        public static readonly ICollection<IGluon> ConstantGluons = new List<IGluon>
        {
            new Gluon(),
            new Gluon()
        };

        protected Baryon(ICollection<IQuark> quarks, ICollection<IGluon> gluons, double? massInKilograms, double? massInElectronVolts) : base(quarks, gluons, massInKilograms, massInElectronVolts)
        {
            if (quarks.Count < 3)
            {
                throw new ArgumentException("Baryons require at least three (3) quarks.");
            }

            if (quarks.Count - 1 != gluons.Count)
            {
                throw new ArgumentException($"A gluon is required to bind two (2) quarks together. This Baryon contains {gluons.Count} gluons and {quarks.Count - 1} were expected.");
            }
        }
    }
}
