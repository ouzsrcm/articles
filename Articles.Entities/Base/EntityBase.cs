using System;

namespace Articles.Entities.Base
{
    public class EntityBase
    {
        public Guid UniqueId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public int CreationUserId { get; set; }
    }
}
