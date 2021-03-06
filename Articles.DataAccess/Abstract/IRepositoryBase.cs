﻿using Articles.Entities.Base;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Articles.DataAccess.Abstract
{
    public interface IRepositoryBase<T> where T : class, IEntityBase
    {
        Task<T> FindBy(Expression<Func<T, bool>> expression);
        IQueryable<T> Get(Expression<Func<T, bool>> expression);
        IQueryable<T> Get();
        T Add(T entity);
        void Update(T entity);
        void Delete(Guid UniqueId);
        Task<int> Save();
    }
}
