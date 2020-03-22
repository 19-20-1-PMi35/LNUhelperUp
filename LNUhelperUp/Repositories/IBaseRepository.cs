using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LNUhelperUp.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity: class 
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> WhereMultipleIncludeAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> WhereMultipleInclude(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> expressionForWhere,
            Expression<Func<TEntity, object>> orderingExpression,
            bool isAsc,
            params Expression<Func<TEntity, object>>[] includes);

    }
}
