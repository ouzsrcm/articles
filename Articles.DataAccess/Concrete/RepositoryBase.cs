using Articles.DataAccess.Abstract;
using Articles.Entities;
using Articles.Entities.Base;
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

        public void Add(T entity)
        {
            entity.UniqueId = Guid.NewGuid();
            entity.CreationDate = DateTime.Now;
            this.databaseContext.AddAsync<T>(entity);
        }

        public void Delete(T entity)
        {
            entity.DeletionDate = DateTime.Now;
            entity.IsDeleted = true;
            Update(entity);
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
            this.databaseContext.Update<T>(entity);
        }
    }
}
