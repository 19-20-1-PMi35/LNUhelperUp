using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LNUhelperUp.Repositories
{
    abstract public class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity: class
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _entities.FindAsync();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }
        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _entities.Where(expression).ToListAsync();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _entities.SingleOrDefaultAsync(expression);
        }

        public async Task<TEntity> WhereMultipleIncludeAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            return await _entities.IncludeMultiple(expression, includes);
        }

        public IQueryable<TEntity> WhereMultipleInclude(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            return _entities.WhereIncludeMultiple(expression, includes);
        }

        public IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> expressionForWhere,
            Expression<Func<TEntity, object>> orderingExpression,
            bool isAsc,
            params Expression<Func<TEntity, object>>[] includes)
        {
            if (isAsc)
            {
                return _entities
              .WhereIncludeMultiple(expressionForWhere, includes)
              .OrderBy(orderingExpression);
            }

            return _entities
             .WhereIncludeMultiple(expressionForWhere, includes)
             .OrderByDescending(orderingExpression);
        }
    }
}
