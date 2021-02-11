using System;

namespace Articles.Entities.Base
{
    public interface IEntityBase
    {
        Guid UniqueId { get; set; }
        public DateTime CreationDate { get; set; }
        bool IsDeleted { get; set; }
        bool IsPublished { get; set; }
        int CreationUserId { get; set; }
        public DateTime DeletionDate { get; set; }
    }
}