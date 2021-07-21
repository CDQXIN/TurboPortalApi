using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TurboPortalApi.Entity;

namespace TurboPortalApi.Core
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> ListAll();
        IQueryable<TEntity> ListById(int id);
        IQueryable<TEntity> ListByCustom(Expression<Func<TEntity, bool>> filter);
        int Insert(TEntity entity);
        int Update(TEntity entity);
        void Delete(int id);
    }
}
