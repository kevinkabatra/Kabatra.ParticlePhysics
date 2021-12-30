namespace SubatomicParticles.UnitTests.DataModels
{
    using System;

    public abstract class SubatomicParticleTest : IDisposable
    {
        public virtual void Dispose()
        {
            // Reset the singleton in between tests
            Universe.DataModels.Universe.Reset();

            // Prevents Garbage Collector from wasting time
            // https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1816
            GC.SuppressFinalize(this);
        }
    }
}
