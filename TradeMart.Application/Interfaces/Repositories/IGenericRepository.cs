namespace TradeMart.Application.Interfaces.Repositories;
public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync<G>(G id);
    IQueryable<T> GetDataQuery();
    Task<IReadOnlyList<T>> GetAllAsync();
    void Add(T entity);
    void AddRange(List<T> entities);
    void Update(T entity);
    void UpdateRange(List<T> entities);
    void Delete<G>(G id);
    void DeleteRange(List<T> entities);
    Task SaveAsync();
}
