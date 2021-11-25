
using System.Collections.Concurrent;
using FeatureFlagServer.Entities;
using FeatureFlagServer.Interfaces;
namespace FeatureFlagServer.Services
{
    public class MemoryFlagRepository : IEntityRepository<FlagEntity, int>
    {
        private readonly ILogger<MemoryFlagRepository> logger;
        private readonly ConcurrentDictionary<int, FlagEntity> flags;

        public MemoryFlagRepository(ILogger<MemoryFlagRepository> logger) {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            flags = new ConcurrentDictionary<int, FlagEntity>();
            flags.TryAdd(1, FlagEntity.Create(1, true));
            flags.TryAdd(2, FlagEntity.Create(2, false));
        }

        public Task<FlagEntity> CreateAsync(FlagEntity entity)
        {
            if (flags.Any(f => f.Key == entity.Id))
            {
                return Task.FromResult<FlagEntity>(default);
            }

            var result = flags.TryAdd(entity.Id, entity) ? entity : default;
            return Task.FromResult(result);
        }

        public Task DeleteAsync(FlagEntity entity)
        {
            var result = flags.TryRemove(entity.Id, out _);
            return Task.CompletedTask;
        }

        public Task<FlagEntity> ReadAsync(int Id)
        {
            var result = flags.TryGetValue(Id, out var flag) ? flag : default;
            return Task.FromResult(result);
        }

        public Task<FlagEntity> UpdateAsync(FlagEntity entity)
        {

            var result = flags.TryRemove(entity.Id, out _) 
                        && flags.TryAdd(entity.Id, entity) ?
                        entity : default;

            return Task.FromResult(result);
        }
    }
}
