using Application.Shared.Domain.Interfaces;
using Application.Shared.Infraestructure.Interfaces;

namespace Application.Shared.Domain.Repository;

public class RepositoryGeneric<TEntity>(IRepository<TEntity>repository): IRepositoryGeneric<TEntity> where TEntity : class
{
    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await repository.GetAll();
    }

    public async Task<TEntity> GetById(int id)
    {
        return await repository.GetById(id);
    }

    public async Task Add(TEntity entity)
    {
        await repository.Add(entity);
    }

    public async Task Update(TEntity entity)
    {
        await repository.Update(entity);
    }

    public async Task Delete(int id)
    {
        await repository.Delete(id);
    }
}