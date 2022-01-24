namespace Universe.Events.BetaDecay
{
    using System.Collections.Generic;

    /// <summary>
    /// https://en.wikipedia.org/wiki/Beta_decay
    /// https://education.jlab.org/glossary/betadecay.html#:~:text=There%20are%20two%20types%20of,an%20electron%20and%20an%20antineutrino.&text=During%20beta%2Dplus%20decay%2C%20a,a%20positron%20and%20a%20neutrino.
    /// </summary>
    public interface IBetaDecayEvent
    {
        public object ParticleThatExperiencesDecay { get; }
        public IEnumerable<object> ParticlesThatAreCreatedDueToDecay { get; } 
    }
}
