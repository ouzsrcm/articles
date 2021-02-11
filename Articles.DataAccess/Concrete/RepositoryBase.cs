using Articles.DataAccess.Abstract;
using Articles.Entities;
using Articles.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Articles.DataAccess.Concrete
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntityBase
    {
        public DatabaseContext databaseContext;
        public RepositoryBase(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public T Add(T entity)
        {
            if (entity.UniqueId == Guid.Empty)
                entity.UniqueId = Guid.NewGuid();

            entity.CreationDate = DateTime.Now;
            entity.IsDeleted = false;

            this.databaseContext.Add<T>(entity);
            return entity;
        }

        public void Delete(Guid UniqueId)
        {
            var entity = Get(x => x.UniqueId == UniqueId).FirstOrDefault();
            if (entity == null)
                return;
            entity.DeletionDate = DateTime.Now;
            entity.IsDeleted = true;
            this.databaseContext.Update<T>(entity);
        }

        public async Task<T> FindBy(Expression<Func<T, bool>> expression)
        {
            return await this.databaseContext.Set<T>().FindAsync(expression);
        }

        public IQueryable<T> Get()
        {
            return this.databaseContext.Set<T>().Where(x => x.IsDeleted == false);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            var res = this.databaseContext.Set<T>().Where(x => x.IsDeleted == false);
            return res.Where(expression);
        }

        public Task<int> Save()
        {
            return this.databaseContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            this.databaseContext.Entry(entity).State = EntityState.Modified;
            //this.databaseContext.Update<T>(entity);
        }
    }
}
