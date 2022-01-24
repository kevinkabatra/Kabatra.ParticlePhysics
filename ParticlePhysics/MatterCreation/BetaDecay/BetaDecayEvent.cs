namespace Universe.Events.BetaDecay
{
    using System;
    using System.Collections.Generic;

    /// <inheritdoc cref="IBetaDecayEvent"/>
    public class BetaDecayEvent : EventArgs, IBetaDecayEvent
    {
        /// <inheritdoc cref="IBetaDecayEvent.ParticleThatExperiencesDecay"/>
        public object ParticleThatExperiencesDecay { get; }

        /// <inheritdoc cref="IBetaDecayEvent.ParticlesThatAreCreatedDueToDecay"/>
        public IEnumerable<object> ParticlesThatAreCreatedDueToDecay { get; }

        public BetaDecayEvent(object particleThatExperiencesDecay, ICollection<object> particlesThatAreCreatedDueToDecay)
        {
            if (particlesThatAreCreatedDueToDecay.Count != 3)
            {
                throw new ArgumentException($"Beta Decay creates three (3) particles, please provide exactly three (3) particles to create, you provided {particlesThatAreCreatedDueToDecay.Count}.");
            }

            ParticleThatExperiencesDecay = particleThatExperiencesDecay;
            ParticlesThatAreCreatedDueToDecay = particlesThatAreCreatedDueToDecay;
        }
    }
}
