namespace Universe.DataModels
{
    using System.Collections.Generic;
    using Kabatra.Common.Singleton;

    public class Universe : SingletonBase<Universe>
    {
        public List<object> SubatomicParticles;

        public Universe()
        {
            SubatomicParticles = new List<object>();
        }

    }
}
