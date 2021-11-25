namespace FeatureFlagServer.Models
{
    public class FlagModel
    {
        public int Id { get; init; }
        public bool State { get; init; }

        public FlagModel(int id, bool state)
        {
            Id = id;
            State = state;
        }

        public static FlagModel Create(int id, bool state) => new(id, state);

    }
}
