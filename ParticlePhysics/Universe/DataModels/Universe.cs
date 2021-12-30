namespace Universe.DataModels
{
    using System.Collections.Generic;
    using Kabatra.Common.Singleton;

    /// <summary>
    ///     All of space and time and their contents.
    /// <para>All of the subatomic particles that are created are added to the universe upon creation.
    /// The universe is a singleton object as there is only one universe in real-life.</para>
    /// <para>See the following article for more information, but in this case it has nothing to do with the programming:</para>
    /// <para>1. <a href="https://en.wikipedia.org/wiki/Universe">Wikipedia: Universe</a></para>
    /// </summary>
    public class Universe : SingletonBase<Universe>
    {
        public List<object> SubatomicParticles;

        public Universe()
        {
            SubatomicParticles = new List<object>();
        }

    }
}
