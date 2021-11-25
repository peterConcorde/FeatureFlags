using FeatureFlagServer.Entities;

namespace FeatureFlagServer.Interfaces
{
    public interface IFlagService
    {
        Task<FlagEntity> GetFlagAsync(int id);

        Task<FlagEntity> SetFlagAsync(int id, bool value);
    }
}
