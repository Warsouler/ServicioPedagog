using Resolver.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DataModel.GenericRepository
{
    public class GenericRepository<TEntity> where TEntity:class
    {
        internal ServicioContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ServicioContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        #region CUDActions
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Update(TEntity entity, List<string> modifiedfields)
        {
            context.Entry<TEntity>(entity).State = EntityState.Unchanged;
            
            foreach (string var in modifiedfields)
            {
                context.Entry<TEntity>(entity).Property(var).IsModified = true;
            }
        }
        public virtual void Delete(TEntity entity, List<string> modifiedfields)
        {
            dbSet.Attach(entity);
            context.Entry<TEntity>(entity).State = EntityState.Unchanged;
            foreach (string var in modifiedfields)
            {
                context.Entry<TEntity>(entity).Property(var).IsModified = true;
            }
        }


        #endregion

        #region ReadOneActions
        public virtual TEntity GetById(Int64 ID)
        {
            return dbSet.Find(ID);
        }

        public virtual TEntity GetOneByFilters(Expression<Func<TEntity, bool>> where, params string[] include)
        {
            IQueryable<TEntity> query = this.dbSet.AsNoTracking(); 
            if (include != null)
                query = include.Aggregate(query, (current, inc) => current.Include(inc));
            if (where != null)
                query = query.AsNoTracking().Where(where);
            return query.FirstOrDefault<TEntity>();
        }

        #endregion

        #region ReadAllActions
        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking();
            return query;
        }

        public virtual IQueryable<TEntity> GetAllByFilters(Expression<Func<TEntity, bool>> where, params string[] include)
        {
            //var a = context.PeatonUsers.ToList();
            IQueryable<TEntity> query = this.dbSet.AsNoTracking();
                if (include != null)
                    query = include.Aggregate(query, (current, inc) => current.Include(inc));
                if (where != null)
                    query = query.AsNoTracking().Where(where);
                return query;
            //return dbSet.Where(where).AsQueryable();
        }
        #endregion




    }
}