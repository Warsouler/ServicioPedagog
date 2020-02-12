using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public interface IGenericInterfaceRepository<TEntity> where TEntity : class
    {
        #region CUDActions
        void Insert(TEntity entity);
        void Update(TEntity entity, List<string> modifiedfields);
        void Delete(TEntity entity,List<string> modifiedfields);
        #endregion

        #region ReadOneActions
        TEntity GetById(Int64 ID);
        TEntity GetOneByFilters(Expression<Func<TEntity, bool>> where, params string[] include);
        #endregion

        #region ReadAllActions
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllByFilters(Expression<Func<TEntity, bool>> where, params string[] include);
        
        #endregion
    }
}
