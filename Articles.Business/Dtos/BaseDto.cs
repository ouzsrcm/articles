using System;

namespace Articles.Business.Dtos
{
    public class BaseDto
    {
        public Guid UniqueId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public int CreationUserId { get; set; }
        public DateTime DeletionDate { get; set; }
    }
}
