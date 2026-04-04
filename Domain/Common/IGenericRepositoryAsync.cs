namespace Domain.Common;

public interface IGenericRepositoryAsync<T> where T : EntityBase
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T>GetPagedAsync(int page, int pageSize);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}