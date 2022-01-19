namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using ElementaryParticles.Quarks;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;
    using MatterCreation;

    public class Antineutron : Baryon
    {
        public const ChargeType ConstantChargeType = ChargeType.Neutral;
        public const double ConstantChargeValue = 0d;
        public static readonly double ConstantMassInKilograms = Neutron.ConstantMassInKilograms;
        public const double ConstantMassInElectronVolts = Neutron.ConstantMassInElectronVolts;
        public static readonly Type ConstantAntiparticleType = typeof(Neutron);

        public static readonly ICollection<IQuark> ConstantComposition = new List<IQuark>
        {
            new AntiUpQuark(),
            new AntiDownQuark(),
            new AntiDownQuark()
        };

        public Antineutron() : base(ConstantComposition, ConstantGluons, Neutron.ConstantMassInKilograms, Neutron.ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
        }

        public Antineutron(ICollection<IQuark> quarks, ICollection<IGluon> gluons) : base(quarks, gluons, Neutron.ConstantMassInKilograms, Neutron.ConstantMassInElectronVolts, ConstantAntiparticleType)
        {
            var numberOfAntiUpQuarks = quarks.OfType<AntiUpQuark>().Count();
            var numberOfAntiDownQuarks = quarks.OfType<AntiDownQuark>().Count();

            if (numberOfAntiUpQuarks != 1 && numberOfAntiDownQuarks != 2)
            {
                throw new ArgumentException($"A Neutron requires one (1) AntiUp Quark and two (2) AntiDown Quarks. This Neutron contains {numberOfAntiUpQuarks} Up Quarks and {numberOfAntiDownQuarks} Down Quarks.");
            }
        }
    }

    public class AntineutronCreator : CompositeParticleCreator<Antineutron>
    {
        /// <inheritdoc cref="SubatomicParticleCreator{T}.Create"/>
        public override Antineutron Create()
        {
            var antineutron = new Antineutron();
            TriggerMatterCreationEvent(new MatterCreationEvent(antineutron));

            return antineutron;
        }

        /// <inheritdoc cref="CompositeParticleCreator{T}.Create(ICollection{IQuark},ICollection{IGluon})"/>
        public override Antineutron Create(ICollection<IQuark> quarks, ICollection<IGluon> gluons)
        {
            var antineutron = new Antineutron(quarks, gluons);
            TriggerMatterCreationEvent(new MatterCreationEvent(antineutron));

            return antineutron;
        }
    }
}
