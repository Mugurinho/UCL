using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using UCL.Models.Data;

namespace UCL.Models
{
    public class RepositoryBase<TContext, TEntity> where TContext : UCLEntities where TEntity : class
    {
        public RepositoryBase(UCLEntities context)
        {
            _entities = context;
        }
        protected UCLEntities _entities;

        public virtual void Add(TEntity entity)
        {
            _entities.Set<TEntity>().Add(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            _entities.Set<TEntity>().AddRange(entities);
        }

        public virtual long Count()
        {
            return _entities.Set<TEntity>().Count();
        }

        public virtual void Remove(TEntity entity)
        {
            _entities.Set<TEntity>().Remove(entity);
        }

        public virtual void Remove(IEnumerable<TEntity> entities)
        {
            _entities.Set<TEntity>().RemoveRange(entities);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return GetAll(x => true);
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null)
        {
            return _entities.Set<TEntity>().Where(where ?? (x => true));
        }

        public virtual void SubmitChanges()
        {
            _entities.SaveChanges();
        }

        public Task<T> RunASASync<T>(Func<T> func)
        {
            return Task.Run(() => func());
        }
    }
}