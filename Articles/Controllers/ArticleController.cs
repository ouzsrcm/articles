using Articles.Business.Dtos;
using Articles.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Articles.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> logger;
        private readonly IArticleService articleService;

        public ArticleController(IArticleService _articleService,
                                 ILogger<ArticleController> _logger)
        {
            logger = _logger;
            articleService = _articleService;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<ArticleDto>> GetAll()
        {
            IEnumerable<ArticleDto> articles = null;
            try
            {
                articles = articleService.Get();
                logger.LogInformation("Makale listesi alındı.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
            return Ok(articles);
        }

        [HttpGet]
        [Route("published")]
        public ActionResult<IEnumerable<ArticleDto>> Published()
        {
            IEnumerable<ArticleDto> articles = null;
            try
            {
                articles = articleService.Get(x => x.IsPublished);
                logger.LogInformation("Makale listesi alındı.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
            return Ok(articles);
        }

        [HttpGet]
        [Route("unpublished")]
        public ActionResult<IEnumerable<ArticleDto>> UnPublished()
        {
            IEnumerable<ArticleDto> articles = null;
            try
            {
                articles = articleService.Get(x => !x.IsPublished);
                logger.LogInformation("Makale listesi alındı.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
            return Ok(articles);
        }

        [HttpGet]
        [Route("ArticleById")]
        public ActionResult<ArticleDto> ArticleById(int ArticleId)
        {
            IEnumerable<ArticleDto> articles = null;
            try
            {
                articles = articleService.Get(x => x.ArticleId == ArticleId);
                logger.LogInformation("Makale listesi alındı.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
            return Ok(articles);
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add([FromBody] ArticleDto model)
        {
            if (model == null)
                return BadRequest("Makale boş olamaz.");

            if (!ModelState.IsValid)
                return BadRequest("Lütfen girmiş olduğunuz değerleri kontrol ediniz.");
            try
            {
                var res = articleService.Add(model);

                logger.LogInformation("Makale eklendi.");

                return Ok(res);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddCategory")]
        public ActionResult AddCategory([FromBody] CategoryDto model)
        {
            if (model == null)
                return BadRequest("Kategori boş olamaz.");

            if (!ModelState.IsValid)
                return BadRequest("Lütfen girmiş olduğunuz değerleri kontrol ediniz.");
            try
            {
                var res = articleService.Add(model);
                return Ok(res);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{UniqueHash}")]
        public ActionResult DeleteArticle(Guid UniqueHash)
        {
            try
            {
                var res = articleService.Delete(UniqueHash);
                logger.LogInformation($"{UniqueHash} id'li makale silindi.");
                return Ok(res ? "Makale kaydı başarıyla silindi." : "Makale silinemedi");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
