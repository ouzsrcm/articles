using System;

namespace Articles.Entities.Base
{
    public interface IEntityBase
    {
        Guid UniqueId { get; set; }
        DateTime CreationDate { get; set; }
        bool IsDeleted { get; set; }
        bool IsPublished { get; set; }
        int CreationUserId { get; set; }
    }
}