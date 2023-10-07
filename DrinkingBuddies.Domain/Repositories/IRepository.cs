namespace DrinkingBuddies.Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity input);
        Task DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByNameAsync(string name);
        Task<int> GetNumberAsync();
        Task<bool>  IsAdminAsync();
    }
}
