using Articles.DataAccess.Abstract;
using Articles.Entities;
using Articles.Entities.RecordStructure;

namespace Articles.DataAccess.Concrete
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(DatabaseContext _databaseContext)
            : base(_databaseContext)
        {

        }
    }
}
