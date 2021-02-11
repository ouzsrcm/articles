using Articles.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Articles.Entities.RecordStructure
{
    public class Category : EntityBase, IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

    }
}
