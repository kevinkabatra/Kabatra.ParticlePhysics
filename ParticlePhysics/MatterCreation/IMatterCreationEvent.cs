namespace MatterCreation
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Matter_creation
    /// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-publish-events-that-conform-to-net-framework-guidelines
    /// </summary>
    public interface  IMatterCreationEvent
    {
        object Particle { get; }
    }
}
