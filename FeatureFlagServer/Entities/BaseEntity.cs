namespace FeatureFlagServer.Entities
{
    public abstract class BaseEntity<T> where T : IComparable
    {
        public T Id { get; init; }

    }
}
