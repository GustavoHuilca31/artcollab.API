namespace Application.Shared.Domain.Interfaces;

public interface IRepositoryGeneric<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(int id);
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(int id);
}