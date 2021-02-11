using Articles.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Articles.Entities.RecordStructure
{
    public class Comment : EntityBase, IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public int ParentCommentId { get; set; }
        public int ArticleId { get; set; }

        public int UserId { get; set; }
        public string Content { get; set; }

        public virtual Article Article { get; set; }
    }
}
