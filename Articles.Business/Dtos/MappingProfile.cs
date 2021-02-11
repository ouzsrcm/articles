using Articles.Entities.RecordStructure;
using AutoMapper;

namespace Articles.Business.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Article, ArticleDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
