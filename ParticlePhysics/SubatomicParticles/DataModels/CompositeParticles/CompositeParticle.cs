﻿namespace SubatomicParticles.DataModels.CompositeParticles
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Constants;
    using Interfaces;
    using Interfaces.CompositeParticles;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;

    /// <inheritdoc cref="ICompositeParticle"/>
    public abstract class CompositeParticle : SubatomicParticle, ICompositeParticle
    {
        /// <remarks>
        ///     Suppressing PossibleMultipleEnumeration warning as I will need to loop through the list twice
        /// since the list contains the necessary data and the object does not yet exist so I cannot use instance
        /// variables to store the data. Storing the data in a static context would just be asking for trouble once
        /// I start creating a large number of Hadrons at the same time.
        ///     This is unfortunate but I rather like the idea of determining the charge and charge type based on
        /// the quarks that are in the Hadron. Hadrons will typically have two or three quarks so the performance
        /// impact should be negligible. They can of course contain more, so long as each quark has an antiquark to
        /// balance it out, but I am not sure that there is any point in creating a Hadron with 3 + n number of quarks
        /// if the n quarks do nothing at all.
        /// </remarks>
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        protected CompositeParticle(IEnumerable<IQuark> quarks, IEnumerable<IGluon> gluons, double? massInKilograms, double? massInElectronVolts,  Type typeOfAntiParticle) : base(
            GetChargeType(GetCharge(quarks)),
            GetCharge(quarks),
            massInKilograms,
            massInElectronVolts,
            typeOfAntiParticle
        )
        {
            if (!ChargeValue.Equals(0) && !ChargeValue.Equals(1) && !ChargeValue.Equals(-1))
            {
                throw new Exception("A composite particle must have a charge value of -1, 0, or 1.");
            }

            Quarks = quarks;
            Gluons = gluons;
        }

        public IEnumerable<IQuark> Quarks { get; }
        public IEnumerable<IGluon> Gluons { get; }

        private static double GetCharge(IEnumerable<IQuark> quarks)
        {
            return quarks.Sum(quark => quark.ChargeValue);
        }

        private static ChargeType GetChargeType(double charge)
        {
            return charge switch
            {
                0 => ChargeType.Neutral,
                > 0 => ChargeType.Positive,
                _ => ChargeType.Negative
            };
        }
    }

    public abstract class CompositeParticleCreator<T> : SubatomicParticleCreator<T> where T : ISubatomicParticle, new()
    {
        /// <summary>
        ///     Creates a subatomic particle of the specified type, with specific Quarks and Gluons, and triggers the MatterCreationEvent.
        /// </summary>
        /// <param name="quarks">The Quarks that will form the particle.</param>
        /// <param name="gluons">The Gluons that will hold the Quarks together.</param>
        /// <returns></returns>
        public abstract ISubatomicParticle Create(ICollection<IQuark> quarks, ICollection<IGluon> gluons);
    }
}
