using InRhythmServer.Models;

namespace InRhythmServer.Services;

public interface IService<T> 
{
    Task<List<T>> GetSomeAsync(IEnumerable<Guid> ids);
    Task<T?> GetAsync(Guid id);
    Task<T> CreateAsync(T entity);
    Task<bool> UpdateAsync(Guid id, T entity);
    Task<bool> DeleteAsync(Guid id);
}