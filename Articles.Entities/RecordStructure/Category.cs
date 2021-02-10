using Articles.Entities.Base;
using System.Collections.Generic;

namespace Articles.Entities.RecordStructure
{
    public class Category : EntityBase, IEntityBase
    {

        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

    }
}
