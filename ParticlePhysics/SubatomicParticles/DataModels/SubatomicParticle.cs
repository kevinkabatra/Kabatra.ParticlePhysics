namespace SubatomicParticles.DataModels
{
    using System;
    using System.Collections.Generic;
    using Constants;
    using Interfaces;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;
    using MatterCreation;

    /// <inheritdoc cref="ISubatomicParticle"/>
    public abstract class SubatomicParticle : ISubatomicParticle
    {
        public ChargeType Charge { get; }
        public double ChargeValue { get; }
        public double? MassInKilograms { get; }
        public double? MassInElectronVolts { get; }
        public Type AntiparticleType { get; }
        public bool HasAttractedToAnotherObject { get; set; }
        
        protected SubatomicParticle(ChargeType charge, double chargeValue, double? massInKilograms, double? massInElectronVolts, Type typeOfAntiparticle)
        {
            Charge = charge;
            ChargeValue = chargeValue;
            MassInKilograms = massInKilograms;
            MassInElectronVolts = massInElectronVolts;
            AntiparticleType = typeOfAntiparticle;
            HasAttractedToAnotherObject = false;
        }

        /// <summary>
        ///     Equality checker.
        /// </summary>
        /// <param name="objectToCompare">Another subatomic particle.</param>
        /// <returns></returns>
        public override bool Equals(object objectToCompare)
        {
            if (objectToCompare is not SubatomicParticle subatomicParticle) return false;

            return
                Charge.Equals(subatomicParticle.Charge)
                && ChargeValue.Equals(subatomicParticle.ChargeValue)
                && MassInKilograms.Equals(subatomicParticle.MassInKilograms)
                && MassInElectronVolts.Equals(subatomicParticle.MassInElectronVolts)
                && HasAttractedToAnotherObject.Equals(subatomicParticle.HasAttractedToAnotherObject);
        }

        /// <summary>
        ///     Need to override GetHashCode when you override Equals, only useful for Hashes.
        /// </summary>
        /// <remarks>
        ///     All derived classes must override this as well, otherwise the compiler will complain.
        /// The derived classes will only return the base implementation.
        /// </remarks>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (typeof(SubatomicParticle) + Charge.ToString() + ChargeValue + MassInKilograms + MassInElectronVolts).GetHashCode();
        }
    }

    /// <summary>
    /// https://refactoring.guru/design-patterns/abstract-factory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISubatomicParticleCreator<T> where T : ISubatomicParticle
    {
        ISubatomicParticle Create();
    }

    /// <summary>
    /// https://stackoverflow.com/questions/8243923/c-sharp-constructor-event\
    /// https://stackoverflow.com/questions/119506/virtual-member-call-in-a-constructor
    /// https://refactoring.guru/design-patterns/factory-method
    /// </summary>
    public abstract class SubatomicParticleCreator<T> : ISubatomicParticleCreator<T> where T : ISubatomicParticle, new()
    {
        // This event will fire whenever a subatomic particle is created, the Universe will listen for this event, and will add the particle to the Universe.
        public event EventHandler<MatterCreationEvent> MatterCreation;

        /// <summary>
        ///     Creates a subatomic particle of the specified type and triggers the MatterCreationEvent.
        /// </summary>
        /// <returns></returns>
        public virtual ISubatomicParticle Create()
        {
            var subatomicParticle = new T();
            TriggerMatterCreationEvent(new MatterCreationEvent(subatomicParticle));

            return subatomicParticle;
        }

        /// <summary>
        ///     Triggers the MatterCreationEvent.
        /// </summary>
        /// <param name="matterCreationEvent"></param>
        protected virtual void TriggerMatterCreationEvent(MatterCreationEvent matterCreationEvent)
        {
            // Make a temporary copy of the event to avoid possibility of a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            var temporaryEvent = MatterCreation;

            // Event will be null if there are no subscribers
            temporaryEvent?.Invoke(this, matterCreationEvent);
        }
    }
}
