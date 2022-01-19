﻿namespace SubatomicParticles.UnitTests.DataModels.ElementaryParticles.Quarks
{
    using Constants;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;

    public class AntiDownQuarkTests : QuarkTests<AntiDownQuark, AntiDownQuarkCreator>
    {
        /// <inheritdoc cref="SubatomicParticleTests{TParticle,TParticleCreator}.ValidateCreation"/>
        protected override void ValidateCreation(AntiDownQuark particle)
        {
            ValidateQuarkCreation(particle, QuarkFlavor.Down, AntiDownQuark.ConstantChargeType, AntiDownQuark.ConstantChargeValue, AntiDownQuark.ConstantMassInElectronVolts, AntiDownQuark.ConstantAntiparticleType);
        }
    }
}
