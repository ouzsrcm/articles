using Articles.Business.Dtos;
using Articles.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
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
    }
}
