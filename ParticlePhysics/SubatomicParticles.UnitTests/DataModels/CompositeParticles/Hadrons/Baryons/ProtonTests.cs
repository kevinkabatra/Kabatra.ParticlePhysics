namespace SubatomicParticles.UnitTests.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces.ElementaryParticles.Quarks;
    using SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons;
    using SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Xunit;

    public class ProtonTests
    {
        [Fact]
        public void CanMakeProton()
        {
            var proton = new Proton();
            ValidateProtonCreation(proton);
        }

        [Fact]
        public void CanMakeProtonFromQuarksAndGluons()
        {
            var proton = new Proton(Proton.ConstantComposition, Baryon.ConstantGluons);
            ValidateProtonCreation(proton);
        }

        [Fact]
        public void CannotMakeNeutronWithIncorrectCharge()
        {
            var wrongQuarks = new List<IQuark>
            {
                new UpQuark(),
                new UpQuark(),
                new UpQuark()
            };

            Assert.Throws<Exception>(() => new Proton(wrongQuarks, Baryon.ConstantGluons));
        }

        [Fact]
        public void CannotMakeNeutronWithIncorrectQuarks()
        {
            Assert.Throws<ArgumentException>(() => new Proton(Neutron.ConstantComposition, Baryon.ConstantGluons));
        }

        [Fact]
        public void ProtonIsAddedToUniverseUponCreation()
        {
            var proton = new Proton();
            var universe = Universe.DataModels.Universe.GetOrCreateInstance();

            Assert.Contains(proton, universe.SubatomicParticles);
        }

        // ReSharper disable once SuggestBaseTypeForParameter
        private static void ValidateProtonCreation(Proton proton)
        {
            Assert.NotNull(proton);

            var quarks = Proton.ConstantComposition.ToList();
            Assert.Collection(proton.Quarks,
                firstQuark => Assert.Equal(quarks[0], firstQuark),
                secondQuark => Assert.Equal(quarks[1], secondQuark),
                thirdQuark => Assert.Equal(quarks[2], thirdQuark)
            );

            Assert.Equal(Proton.ConstantAntiparticleType, proton.AntiparticleType);
            Assert.Equal(Baryon.ConstantGluons.Count, proton.Gluons.Count());
            Assert.Equal(Proton.ConstantChargeType, proton.Charge);
            Assert.Equal(Proton.ConstantChargeValue, proton.ChargeValue);
            Assert.Equal(Proton.ConstantMassInKilograms, proton.MassInKilograms);
            Assert.Equal(Proton.ConstantMassInElectronVolts, proton.MassInElectronVolts);
        }
    }
}
