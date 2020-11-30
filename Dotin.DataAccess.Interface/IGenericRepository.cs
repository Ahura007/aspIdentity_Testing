using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dotin.Domain.Model.Model.Application;
using Dotin.Domain.Model.Model.Application.Base;
using Microsoft.EntityFrameworkCore.Query;

namespace Dotin.DataAccess.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        TEntity GetById(params object[] keyValues);

        TEntity GetFirstOrDefault(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true
        );

        Task<List<TEntity>> GetAllAsync();
        List<TEntity> GetAll();

        IEnumerable<TEntity> GetMultiple(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true
        );

        IQueryable<TEntity> FromSql(string sql, params object[] parameters);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Delete(IEnumerable<TEntity> entities);

        int Count(Expression<Func<TEntity, bool>> predicate = null);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}