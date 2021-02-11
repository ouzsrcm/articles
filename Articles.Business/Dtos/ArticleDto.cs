using System.ComponentModel.DataAnnotations;

namespace Articles.Business.Dtos
{
    public class ArticleDto : BaseDto
    {
        public int ArticleId { get; set; }

        [Required(ErrorMessage = "Kategori bilgisi boş olamaz.")]
        public int CategoryId { get; set; }

        public string SeoUrl { get; set; }

        public string Permalink { get; set; }

        [StringLength(1000)]
        [Required(ErrorMessage = "Başlık alanı gereklidir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Makale kısa açıklaması gereklidir.")]
        public string ShortDescription { get; set; }

        public string CoverImage { get; set; }

        [Required(ErrorMessage = "Makale içeriği gereklidir.")]
        public string Content { get; set; }
    }
}