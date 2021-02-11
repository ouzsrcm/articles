using Articles.Entities.RecordStructure;
using AutoMapper;

namespace Articles.Business.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<ArticleDto, Article>();
            CreateMap<CommentDto, Comment>();
            CreateMap<CategoryDto, Category>();

            CreateMap<User, UserDto>();
            CreateMap<Article, ArticleDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
