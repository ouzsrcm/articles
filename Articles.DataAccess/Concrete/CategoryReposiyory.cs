using Articles.DataAccess.Abstract;
using Articles.Entities;
using Articles.Entities.RecordStructure;

namespace Articles.DataAccess.Concrete
{
    public class CategoryReposiyory : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryReposiyory(DatabaseContext _databaseContext)
            : base(_databaseContext)
        {

        }
    }
}
