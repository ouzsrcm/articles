using Articles.Business.Dtos;
using Articles.Entities.RecordStructure;
using System;
using System.Linq.Expressions;

namespace Articles.Business.Services.Abstract
{
    public interface IUserService
    {
        UserDto Get(Expression<Func<User, bool>> expression);
    }
}
