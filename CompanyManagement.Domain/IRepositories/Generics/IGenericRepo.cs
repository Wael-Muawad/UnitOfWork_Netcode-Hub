using System.Linq.Expressions;

namespace CompanyManagement.Domain.IRepositories.Generics;

public interface IGenericRepo<TEntity, TKey>
                    where TEntity : class
                    where TKey : IEquatable<TKey>
{
    Task<TEntity?> GetById(TKey id);
    Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> GetAll();
    Task Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
