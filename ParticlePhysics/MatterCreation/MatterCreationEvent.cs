namespace MatterCreation
{
    using System;

    /// <inheritdoc cref="IMatterCreationEvent"/>
    public class MatterCreationEvent : EventArgs, IMatterCreationEvent
    {
        /// <inheritdoc cref="IMatterCreationEvent.Particle"/>
        public object Particle { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="particleToAdd"></param>
        public MatterCreationEvent(object particleToAdd)
        {
            Particle = particleToAdd;
        }
    }
}
