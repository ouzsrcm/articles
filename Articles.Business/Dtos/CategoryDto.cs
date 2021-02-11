namespace Articles.Business.Dtos
{
    public class CategoryDto : BaseDto
    {
        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public string Name { get; set; }
    }
}
