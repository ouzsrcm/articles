using Articles.Business.Dtos;
using Articles.Business.Services.Abstract;
using Articles.DataAccess.Abstract;
using Articles.Entities.RecordStructure;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Articles.Business.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IMapper mapper;

        private readonly IArticleRepository articleRepository;
        private readonly ICommentRepository commentRepository;
        private readonly ICategoryRepository categoryRepository;

        public ArticleService(IArticleRepository _articleRepository,
                              ICommentRepository _commentRepository,
                              ICategoryRepository _categoryRepository,
                              IMapper _mapper)
        {
            this.mapper = _mapper;

            this.articleRepository = _articleRepository;
            this.commentRepository = _commentRepository;
            this.categoryRepository = _categoryRepository;

        }

        /// <summary>
        /// Makale eklemek için kullanılacak.
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public ArticleDto Add(ArticleDto article)
        {
            if (article.CategoryId == 0)
                throw new Exception("Kategori bilgisi boş olamaz.");

            var entity = mapper.Map<Article>(article);

            var res = articleRepository.Add(entity);
            if (res == null)
                throw new Exception("Makale eklenemedi!");

            Save();

            return mapper.Map<ArticleDto>(res);
        }

        public CategoryDto Add(CategoryDto category)
        {
            if (string.IsNullOrEmpty(category.Name))
                throw new Exception("Kategori adı boş olamaz!");

            var entity = mapper.Map<Category>(category);
            var res = categoryRepository.Add(entity);

            SaveCategory();
            
            return mapper.Map<CategoryDto>(res);
        }

        /// <summary>
        /// Yorum eklemek için kullanılacak.
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public CommentDto AddComment(CommentDto article)
        {
            var entity = mapper.Map<Comment>(article);
            commentRepository.Add(entity);
            return article;
        }

        /// <summary>
        /// Makale silmek için kullanılacak.
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public bool Delete(ArticleDto article)
        {
            var entity = mapper.Map<Article>(article);
            articleRepository.Delete(entity);
            return true;
            //TODO: delete metodu void olmamalıydı.
        }

        /// <summary>
        /// Yorum silmek için kullanılacak.
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public bool DeleteComment(CommentDto article)
        {
            var entity = mapper.Map<Comment>(article);
            commentRepository.Delete(entity);
            return true;
        }

        /// <summary>
        /// Liste yada tekil makale getirmek için kullanılacak.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IEnumerable<ArticleDto> Get()
        {
            var res = articleRepository.Get();
            return mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDto>>(res);
        }

        /// <summary>
        /// Liste yada tekil makale getirmek için kullanılacak.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IEnumerable<ArticleDto> Get(Expression<Func<Article, bool>> expression)
        {
            var res = articleRepository.Get(expression);
            return mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDto>>(res);
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Makale bazlı yada genel yorum listesi almak için kullanılacak.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IEnumerable<Comment> GetComments(Expression<Func<Comment, bool>> expression)
        {
            return commentRepository.Get(expression);
        }

        /// <summary>
        /// Makale işlemlerinden sonra çağırılmalı.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return articleRepository.Save().Result;
            //TODO: Burda loglama yapılabilir.
        }

        public int SaveCategory()
        {
            return categoryRepository.Save().Result;
        }

        /// <summary>
        /// Yorum işlemlerinden sonra yapılmalı.
        /// </summary>
        /// <returns></returns>
        public int SaveComment()
        {
            return commentRepository.Save().Result;
        }

        /// <summary>
        /// Makale güncellemek için kullanılmalı.
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public ArticleDto Update(ArticleDto article)
        {
            var entity = mapper.Map<Article>(article);
            articleRepository.Update(entity);
            return article;
        }
    }
}
