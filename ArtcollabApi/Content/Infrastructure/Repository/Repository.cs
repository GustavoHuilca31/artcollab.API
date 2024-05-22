using Application.Shared.Infraestructure.Context;
using Application.Shared.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Shared.Infraestructure.Repository;

public class Repository<TEntity>(ArtCollabDbContext context): IRepository<TEntity> where TEntity : class
{
    private readonly ArtCollabDbContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Add(TEntity entity)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception(e.Message);
            }
        }
    }

    public async Task Update(TEntity entity)
    { 
        using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _dbSet.Update(entity);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception(e.Message);
                }
            }
    }

    public async Task Delete(int id)
    {
       using (var transaction = _context.Database.BeginTransaction())
       {
           try
           {
               var entity = await _dbSet.FindAsync(id);
               _dbSet.Remove(entity);
               await _context.SaveChangesAsync();
               transaction.Commit();
           }
           catch (Exception e)
           {
               transaction.Rollback();
               throw new Exception(e.Message);
           }
       }
    }
}