namespace FeatureFlagServer.Entities
{
    public class FlagEntity : BaseEntity<int>
    {
        public bool State { get; set; }

        internal static FlagEntity Create(int v1, bool v2)
        {
            return new FlagEntity { Id = v1, State = v2 };
        }
    }
}
