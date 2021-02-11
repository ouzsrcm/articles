using Articles.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Articles.DataAccess.Abstract
{
    public interface IRepositoryBase<T> where T : class, IEntityBase
    {
        IEnumerable<T> FindBy(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Save();
    }
}
