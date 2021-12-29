﻿namespace SubatomicParticles.DataModels
{
    using Constants;
    using Interfaces;

    public class CompositeParticle: ICompositeParticle
    {
        public CompositeParticle(ChargeType charge, double mass)
        {
            Charge = charge;
            Mass = mass;
        }

        public ChargeType Charge { get; }
        public double Mass { get; }
    }
}
