namespace DrinkingBuddies.Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity input);
        Task DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByAccountAsync(string login, string password);
        Task<bool> CheckForExistAsync(string key);
        Task<int> GetElementCountAsync();
    }
}
