﻿using Articles.Business.Dtos;
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
            var entity = mapper.Map<Article>(article);
            articleRepository.Add(entity);
            return article;
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
        public IEnumerable<Article> Get(Expression<Func<Article, bool>> expression)
        {
            return articleRepository.FindBy(expression);
        }

        /// <summary>
        /// Makale bazlı yada genel yorum listesi almak için kullanılacak.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IEnumerable<Comment> GetComments(Expression<Func<Comment, bool>> expression)
        {
            return commentRepository.FindBy(expression);
        }

        /// <summary>
        /// Makale işlemlerinden sonra çağırılmalı.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return articleRepository.Save();
        }

        /// <summary>
        /// Yorum işlemlerinden sonra yapılmalı.
        /// </summary>
        /// <returns></returns>
        public int SaveComment()
        {
            return commentRepository.Save();
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