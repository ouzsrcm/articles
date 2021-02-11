using Articles.Business.Services.Abstract;
using Articles.DataAccess.Abstract;
using Articles.Entities.RecordStructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Articles.Business.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            this.userRepository = _userRepository;
        }

        public IEnumerable<User> Get(Expression<Func<User, bool>> expression)
        {
            return userRepository.FindBy(expression);
        }
    }
}
