namespace SubatomicParticles.DataModels.CompositeParticles.Hadrons
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Constants;
    using Interfaces.CompositeParticles.Hadrons;
    using Interfaces.ElementaryParticles.Quarks;

    /// <inheritdoc cref="IHadron"/>
    public abstract class Hadron : CompositeParticle, IHadron
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
        protected Hadron(IEnumerable<IQuark> quarks, double? massInKilograms, double? massInElectronVolts) : base(
            GetChargeType(GetCharge(quarks)),
            GetCharge(quarks),
            massInKilograms,
            massInElectronVolts
        )
        {
            Quarks = quarks;
        }

        public IEnumerable<IQuark> Quarks { get; }

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
}
