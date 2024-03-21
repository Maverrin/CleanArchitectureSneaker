
using Domain.Entities;

namespace Application.Abstractions;

public interface IGenericRepository<T> where T : class
{
    public Task<T> Add(T entity);
    public Task<T> Update(T entity);
    public Task DeleteById(Guid id);
    public Task<T> GetById(Guid id);
    public Task<List<T>> GetAll();
    public List<T> GetAllPredicate(Func<Sneaker, bool> where, Func<Sneaker, object> order);
}
