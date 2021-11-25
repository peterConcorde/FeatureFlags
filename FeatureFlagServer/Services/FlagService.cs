using FeatureFlagServer.Entities;
using FeatureFlagServer.Interfaces;

namespace FeatureFlagServer.Services
{
    public class FlagService : IFlagService
    {
        private readonly ILogger<FlagService> logger;
        private readonly IEntityRepository<FlagEntity, int> flagRepo;

        public FlagService(ILogger<FlagService> logger, IEntityRepository<FlagEntity, int> flagRepo)
        {
            this.logger = logger;
            this.flagRepo = flagRepo;
        }

        public async Task<FlagEntity> GetFlagAsync(int id)
        {
            return await flagRepo.ReadAsync(id);
        }

        public async Task<FlagEntity> SetFlagAsync(int id, bool value)
        {
            return await flagRepo.UpdateAsync(new FlagEntity { Id = id, State = value });
        }
    }
}
