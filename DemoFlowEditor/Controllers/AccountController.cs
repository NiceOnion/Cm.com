using Microsoft.AspNetCore.Mvc;

namespace DemoFlowEditor.Controllers
{
    [ApiController]
    public class AccountController : Controller
    {
        [HttpGet]
        [Route("api/get")]
        public IActionResult Index()
        {
            var result = "bro";
            return new JsonResult(result);
        }
    }
}
