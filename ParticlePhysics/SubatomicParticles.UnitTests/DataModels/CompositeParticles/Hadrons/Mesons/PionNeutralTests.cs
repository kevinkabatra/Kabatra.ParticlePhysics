namespace SubatomicParticles.UnitTests.DataModels.CompositeParticles.Hadrons.Mesons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces.ElementaryParticles.Quarks;
    using SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons;
    using SubatomicParticles.DataModels.CompositeParticles.Hadrons.Mesons.Pions;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Xunit;

    public class PionNeutralTests : CompositeParticleTests<PionNeutral, PionNeutralCreator>
    {
        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CanMakeParticleFromQuarksAndGluons"/>
        [Fact]
        public override void CanMakeParticleFromQuarksAndGluons()
        {
            var pionNeutralUp = new PionNeutral(PionNeutral.ConstantCompositionUpQuarks, Meson.ConstantGluons);
            var pionNeutralDown = new PionNeutral(PionNeutral.ConstantCompositionDownQuarks, Meson.ConstantGluons);
            
            ValidateCreation(pionNeutralUp);
            ValidateCreation(pionNeutralDown);
        }

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CannotMakeParticleWithIncorrectCharge"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectCharge()
        {
            var wrongQuarks = new List<IQuark>
            {
                new UpQuark(),
                new UpQuark(),
                new UpQuark()
            };

            Assert.Throws<Exception>(() => new PionNeutral(wrongQuarks, Meson.ConstantGluons));
        }

        /// <inheritdoc cref="CompositeParticleTests{TParticle,TParticleCreator}.CannotMakeParticleWithIncorrectQuarks"/>
        [Fact]
        public override void CannotMakeParticleWithIncorrectQuarks()
        {
            Assert.Throws<ArgumentException>(() => new PionNeutral(PionNegative.ConstantComposition, Meson.ConstantGluons));
        }

        /// <inheritdoc cref="SubatomicParticleTests{TParticle,TParticleCreator}.ValidateCreation"/>
        protected override void ValidateCreation(PionNeutral particle)
        {
            Assert.True(ValidateComposition(particle));
            Assert.Equal(PionNeutral.ConstantAntiparticleType, particle.AntiparticleType);
            Assert.Equal(Meson.ConstantGluons.Count, particle.Gluons.Count());
            Assert.Equal(PionNeutral.ConstantChargeType, particle.Charge);
            Assert.Equal(PionNeutral.ConstantChargeValue, particle.ChargeValue);
            Assert.Null(particle.MassInKilograms);
            Assert.Equal(PionNeutral.ConstantMassInElectronVolts, particle.MassInElectronVolts);
        }

        private static bool ValidateComposition(PionNeutral particle)
        {
            var upQuarks = PionNeutral.ConstantCompositionUpQuarks.ToList();
            var downQuarks = PionNeutral.ConstantCompositionDownQuarks.ToList();

            return particle.Quarks.Contains(upQuarks[0]) && particle.Quarks.Contains(upQuarks[1]) ||
                   particle.Quarks.Contains(downQuarks[0]) && particle.Quarks.Contains(downQuarks[1]);
        }
    }
}
