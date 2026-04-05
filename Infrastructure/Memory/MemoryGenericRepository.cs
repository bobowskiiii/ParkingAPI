using Domain.Common;

namespace Infrastructure.Memory;

public class MemoryGenericRepository<T> : IGenericRepositoryAsync<T> where T : EntityBase
{
    protected Dictionary<Guid, T> _data = new();
    
    public Task<T?> GetByIdAsync(Guid id)
    {
        var result = _data.GetValueOrDefault(id);
        return Task.FromResult(result);
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        var result = _data.Values.AsEnumerable();
        return Task.FromResult(result);
    }

    public Task<PagedResult<T?>> GetPagedAsync(int page, int pageSize)
    {
        var all = _data.Values.AsEnumerable();
        var items = all
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        var result = new PagedResult<T?>(items,all.Count(), page, pageSize);
        return Task.FromResult(result);
    }

    public Task<T> AddAsync(T entity)
    {
        if (_data.ContainsKey(entity.Id))
            throw new InvalidOperationException("Entity already exists");
        
        _data[entity.Id] = entity;
        return Task.FromResult(entity);
    }

    public Task<T> UpdateAsync(T entity)
    { 
        if (!_data.ContainsKey(entity.Id))  
            throw new InvalidOperationException("Entity does not exist");
        
        _data[entity.Id] = entity;
        return Task.FromResult(entity);
    }

    public Task DeleteAsync(Guid id)
    {
        if (!_data.ContainsKey(id))
            throw new InvalidOperationException("Entity does not exist");
        
        _data.Remove(id);
        return Task.CompletedTask;
    }
}