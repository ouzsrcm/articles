using Articles.DataAccess.Abstract;
using Articles.Entities;
using Articles.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Articles.DataAccess.Concrete
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntityBase
    {
        public DatabaseContext databaseContext;
        public RepositoryBase(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public void Add(T entity)
        {
            entity.CreationDate = DateTime.Now;
            this.databaseContext.Add<T>(entity);
        }

        public void Delete(T entity)
        {
            entity.DeletionDate = DateTime.Now;
            entity.IsDeleted = true;
            Update(entity);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> expression)
        {
            var res = this.databaseContext.Set<T>().Where(expression);
            return res.Where(x => x.IsDeleted == false);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            var res = this.databaseContext.Set<T>().Where(expression);
            return res.Where(x => x.IsDeleted == false).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return this.databaseContext.Set<T>().Where(x => x.IsDeleted == false);
        }

        public int Save()
        {
            return this.databaseContext.SaveChanges();
        }

        public void Update(T entity)
        {
            this.databaseContext.Update<T>(entity);
        }
    }
}
