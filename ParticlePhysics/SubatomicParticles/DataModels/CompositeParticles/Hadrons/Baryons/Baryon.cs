namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using Interfaces.CompositeParticles.Hadrons.Baryons;
    using Interfaces.ElementaryParticles.Quarks;

    /// <inheritdoc cref="IBaryon"/>
    public abstract class Baryon : Hadron, IBaryon
    {
        protected Baryon(ICollection<IQuark> quarks, double? massInKilograms, double? massInElectronVolts) : base(quarks, massInKilograms, massInElectronVolts)
        {
            if (quarks.Count < 3)
            {
                throw new ArgumentException("Baryons require at least three (3) quarks.");
            }
        }
    }
}
