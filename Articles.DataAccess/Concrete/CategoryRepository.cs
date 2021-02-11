using Articles.DataAccess.Abstract;
using Articles.Entities;
using Articles.Entities.RecordStructure;

namespace Articles.DataAccess.Concrete
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext _databaseContext)
            : base(_databaseContext)
        {

        }
    }
}
