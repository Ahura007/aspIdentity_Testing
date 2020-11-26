using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dotin.DataAccess.EfImpl.Db.IdentityDbContext;
using Dotin.DataAccess.Interface;
using Dotin.HostApi.DataAccess.Repository.Interface;
using Dotin.HostApi.Domain.Model.Application.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Dotin.HostApi.DataAccess.Repository.Imp
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext ApplicationDbContext;
        protected readonly DbSet<TEntity> DbSet;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
            DbSet = ApplicationDbContext.Set<TEntity>();
        }


        public virtual async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }


        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }


        //public virtual TEntity GetById(params object[] keyValues)
        //{
        //    return DbSet.Find(keyValues);
        //}

        //public virtual TEntity GetFirstOrDefault(
        //    Expression<Func<TEntity, bool>> predicate = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        //    bool disableTracking = true
        //)
        //{
        //    IQueryable<TEntity> query = DbSet;
        //    if (disableTracking)
        //    {
        //        query = query.AsNoTracking();
        //    }
        //    if (include != null)
        //    {
        //        query = include(query);
        //    }
        //    if (predicate != null)
        //    {
        //        query = query.Where(predicate);
        //    }
        //    if (orderBy != null)
        //    {
        //        return orderBy(query).FirstOrDefault();
        //    }
        //    else
        //    {
        //        return query.FirstOrDefault();
        //    }
        //}
        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }
        //public virtual IEnumerable<TEntity> GetMultiple(
        //    Expression<Func<TEntity, bool>> predicate = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        //    bool disableTracking = true
        //)
        //{
        //    IQueryable<TEntity> query = DbSet;
        //    if (disableTracking)
        //    {
        //        query = query.AsNoTracking();
        //    }
        //    if (include != null)
        //    {
        //        query = include(query);
        //    }
        //    if (predicate != null)
        //    {
        //        query = query.Where(predicate);
        //    }
        //    if (orderBy != null)
        //    {
        //        return orderBy(query).ToList();
        //    }
        //    else
        //    {
        //        return query.ToList();
        //    }
        //}



        //public virtual IQueryable<TEntity> FromSql(string sql, params object[] parameters)
        //{
        //    // return _dbSet.FromSql(sql, parameters);
        //    return null;
        //}


        //public virtual void Update(TEntity entity)
        //{
        //    DbSet.Update(entity);
        //}
        //public virtual void Update(IEnumerable<TEntity> entities)
        //{
        //    DbSet.UpdateRange(entities);
        //}


        //public virtual void Delete(object id)
        //{
        //    var entityToDelete = DbSet.Find(id);
        //    if (entityToDelete != null)
        //    {
        //        DbSet.Remove(entityToDelete);
        //    }
        //}
        //public virtual void Delete(TEntity entityToDelete)
        //{
        //    if (ApplicationDbContext.Entry(entityToDelete).State == EntityState.Detached)
        //    {
        //        DbSet.Attach(entityToDelete);
        //    }
        //    DbSet.Remove(entityToDelete);
        //}
        //public virtual void Delete(IEnumerable<TEntity> entities)
        //{
        //    DbSet.RemoveRange(entities);
        //}


        //public virtual int Count(Expression<Func<TEntity, bool>> predicate = null)
        //{
        //    if (predicate == null)
        //    {
        //        return DbSet.Count();
        //    }
        //    else
        //    {
        //        return DbSet.Count(predicate);
        //    }
        //}
        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }


        public async Task<int> SaveChangesAsync()
        {
            return await ApplicationDbContext.SaveChangesAsync();
        }
        public int SaveChanges()
        {
            return ApplicationDbContext.SaveChanges();
        }
    }
}