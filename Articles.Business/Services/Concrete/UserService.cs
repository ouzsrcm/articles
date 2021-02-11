using Articles.Business.Dtos;
using Articles.Business.Services.Abstract;
using Articles.DataAccess.Abstract;
using Articles.Entities.RecordStructure;
using AutoMapper;
using System;
using System.Linq.Expressions;

namespace Articles.Business.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(IUserRepository _userRepository,
            IMapper _mapper)
        {
            this.mapper = _mapper;
            this.userRepository = _userRepository;
        }

        public UserDto Get(Expression<Func<User, bool>> expression)
        {
            var res = userRepository.FindBy(expression);
            return mapper.Map<UserDto>(res.Result);
        }
    }
}