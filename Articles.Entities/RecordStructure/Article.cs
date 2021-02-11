using Articles.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Articles.Entities.RecordStructure
{
    public class Article : EntityBase, IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string SeoUrl { get; set; }

        public string Permalink { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        [MaxLength(3000)]
        public string CoverImage { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
