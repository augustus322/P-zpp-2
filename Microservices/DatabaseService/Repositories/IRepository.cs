public interface IRepository<T>
    where T : class
{
    IQueryable<T> GetAll();
    Task<T?> GetByIdAsync(int id);
    void Add(T entity);
    void Update(T entity);
    Task DeleteAsync(int id);
    Task SaveAsync();
}