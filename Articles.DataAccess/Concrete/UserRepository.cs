using Articles.DataAccess.Abstract;
using Articles.Entities;
using Articles.Entities.RecordStructure;

namespace Articles.DataAccess.Concrete
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DatabaseContext _databaseContext)
            : base(_databaseContext)
        {

        }
    }
}
