using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using DataAccessLayer;

namespace DemoFlowAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private AccountContainer container = new(new Account_SQL_DAL());

        [HttpPost("Login")]
        public int Login([FromBody]Account account)
        {
            return container.Login(account).ID;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody]Account account)
        {
            return Ok() ;
        }
    }
}
