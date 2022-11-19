﻿namespace SubatomicParticles.DataModels.ElementaryParticles
{
    using System.Timers;
    using Constants;
    using Forces;
    using Interfaces.ElementaryParticles;
    using Interfaces.ElementaryParticles.Quarks;

    /// <inheritdoc cref="IGluon"/>
    public class Gluon : ElementaryParticle, IGluon
    {
        public const ChargeType ConstantChargeType = ChargeType.Neutral;
        public const double ConstantChargeValue = 0d;
        public static readonly double ConstantMassInKilograms = 0d;
        public const double ConstantMassInElectronVolts = 0d;

        public readonly Timer AttachQuarkAEvent;
        public readonly Timer AttachQuarkBEvent;

        public Gluon() : base(ConstantChargeType, ConstantChargeValue, ConstantMassInKilograms, ConstantMassInElectronVolts)
        {
            AttachQuarkAEvent = new Timer(10);
            AttachQuarkAEvent.Elapsed += FindAndAttachQuarkA;
            AttachQuarkAEvent.AutoReset = true;
            AttachQuarkAEvent.Enabled = true;

            AttachQuarkBEvent = new Timer(10);
            AttachQuarkBEvent.Elapsed += FindAndAttachQuarkB;
            AttachQuarkBEvent.AutoReset = true;
            AttachQuarkBEvent.Enabled = true;
        }

        public IQuark QuarkA { get; set; }
        public IQuark QuarkB { get; set; }

        private async void FindAndAttachQuarkA(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            QuarkA = await StrongNuclearForce.Attach<IQuark>();
            if (QuarkA == null) return;
            AttachQuarkAEvent.Dispose();
            QuarkA.HasAttractedToAnotherObject = true;
        }

        private async void FindAndAttachQuarkB(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            QuarkB = await StrongNuclearForce.Attach<IQuark>();
            if (QuarkB == null) return;
            AttachQuarkBEvent.Dispose();
            QuarkB.HasAttractedToAnotherObject = true;
        }
    }
}
