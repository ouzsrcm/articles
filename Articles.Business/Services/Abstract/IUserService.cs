using Articles.Entities.RecordStructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Articles.Business.Services.Abstract
{
    public interface IUserService
    {
        IEnumerable<User> Get(Expression<Func<User, bool>> expression);
    }
}
