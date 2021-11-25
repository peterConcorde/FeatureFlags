using FeatureFlagServer.Entities;

namespace FeatureFlagServer.Interfaces
{
    public interface IEntityRepository<T,U> where T : BaseEntity<U> where U : IComparable 
    {
        Task<T> CreateAsync(T entity);
        Task<T> ReadAsync(U Id);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
