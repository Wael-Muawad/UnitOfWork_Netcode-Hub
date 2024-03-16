using CompanyManagement.DataAccess.EFContext;
using CompanyManagement.Domain.IRepositories.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CompanyManagement.DataAccess.Repositories.Generics;

public class GenericRepo<TEntity, TKey> : IGenericRepo<TEntity, TKey>
                        where TEntity : class
                        where TKey : IEquatable<TKey>
{
    private readonly AppDbContext _context;
    //private readonly DbSet<TEntity> _dbSet;

    public GenericRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetById(TKey id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }
}
