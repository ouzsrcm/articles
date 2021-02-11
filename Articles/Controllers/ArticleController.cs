using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Articles.Controllers
{
    [Authorize]
    [ApiController]

    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
