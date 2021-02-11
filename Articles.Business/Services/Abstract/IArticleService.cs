using Articles.Business.Dtos;
using Articles.Entities.RecordStructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Articles.Business.Services.Abstract
{
    public interface IArticleService
    {
        //Articles
        IEnumerable<ArticleDto> Get();
        IEnumerable<ArticleDto> Get(Expression<Func<Article, bool>> expression);
        bool Delete(ArticleDto article);
        bool Delete(Guid ArticleId);
        ArticleDto Add(ArticleDto article);
        ArticleDto Update(ArticleDto article);
        int Save();

        //Categories
        CategoryDto Add(CategoryDto category);
        IEnumerable<CategoryDto> GetCategories();
        int SaveCategory();


        //Comments
        IEnumerable<Comment> GetComments(Expression<Func<Comment, bool>> expression);
        bool DeleteComment(CommentDto article);
        CommentDto AddComment(CommentDto article);
        int SaveComment();
    }
}