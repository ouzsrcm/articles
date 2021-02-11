namespace Articles.Business.Dtos
{
    public class CommentDto : BaseDto
    {
        public int CommentId { get; set; }
        public int ParentCommentId { get; set; }
        public int ArticleId { get; set; }

        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
