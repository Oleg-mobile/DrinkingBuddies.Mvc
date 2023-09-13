namespace DrinkingBuddies.Domain.Repositories
{
	public interface IRepository<TEntity>
	{
		Task AddAsync(TEntity input);
		Task DeleteAsync(int id);
		Task<IEnumerable<TEntity>> GetAsync();
		Task<IEnumerable<TEntity>> GetByIdAsync(int id);
	}
}
