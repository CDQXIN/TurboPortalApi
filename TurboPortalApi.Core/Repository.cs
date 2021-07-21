using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TurboPortalApi.Entity;

namespace TurboPortalApi.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly TurboPortalContext _context;
        //依赖注入
        public Repository(TurboPortalContext context)
        {
            this._context = context;
        }

        public void Delete(int id)
        {
            var res = _context.Set<TEntity>().FirstOrDefault(m => m.Id == id);
            _context.Set<TEntity>().Remove(res);
            _context.SaveChanges();
        }

        public int Insert(TEntity entity)
        {
            var res = _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return res.Entity.Id;
        }

        public IQueryable<TEntity> ListAll()
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> ListByCustom(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().Where(filter);
        }
        public IQueryable<TEntity> ListById(int id)
        {
            return _context.Set<TEntity>().Where(m => m.Id == id);
        }

        public int Update(TEntity entity)
        {
            var res = _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            return res.Entity.Id;
        }
    }
}
