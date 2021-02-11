using Articles.DataAccess.Abstract;
using Articles.Entities;
using Articles.Entities.RecordStructure;

namespace Articles.DataAccess.Concrete
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(DatabaseContext _databaseContext)
            : base(_databaseContext)
        {

        }
    }
}
