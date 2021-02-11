namespace Articles.Business.Dtos
{
    public class ArticleDto : BaseDto
    {
        public int ArticleId { get; set; }

        public int CategoryId { get; set; }

        public string SeoUrl { get; set; }

        public string Permalink { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string CoverImage { get; set; }

        public string Content { get; set; }
    }
}