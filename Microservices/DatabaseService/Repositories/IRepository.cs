public interface IRepository<T>
    where T : class
{
    IQueryable<T> GetAll();
    Task<T?> GetByIdAsync(int id);
    Task<T?> Add(T entity);
    void Update(T entity);
    Task DeleteAsync(int id);
    Task SaveAsync();
}