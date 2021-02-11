using Articles.Business.Dtos;
using Articles.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Articles.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService articleService;

        public ArticleController(IArticleService _articleService)
        {
            articleService = _articleService;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<ArticleDto>> GetAll()
        {
            var res = articleService.Get();
            return Ok(res);
        }

        [HttpGet]
        [Route("published")]
        public ActionResult<IEnumerable<ArticleDto>> Published()
        {
            var res = articleService.Get(x => x.IsPublished);
            return Ok(res);
        }

        [HttpGet]
        [Route("unpublished")]
        public ActionResult<IEnumerable<ArticleDto>> UnPublished()
        {
            var res = articleService.Get(x => !x.IsPublished);
            return Ok(res);
        }

        [HttpGet]
        [Route("ArticleById")]
        public ActionResult<ArticleDto> ArticleById(int ArticleId)
        {
            var res = articleService.Get(x => x.ArticleId == ArticleId);
            return Ok(res);
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

                return Ok(res);
            }
            catch (System.Exception ex)
            {
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
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{UniqueHash}")]
        public ActionResult DeleteArticle(Guid UniqueHash)
        {
            try
            {
                var res = articleService.Delete(UniqueHash);
                return Ok(res ? "Makale kaydı başarıyla silindi." : "Makale silinemedi");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
