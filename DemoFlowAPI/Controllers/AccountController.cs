using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using DataAccessLayer;

namespace DemoFlowAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private AccountContainer container = new(new Account_SQL_DAL());
        [HttpGet (Name = "GetAccountByLogin/{name}/{password}")]
        public IEnumerable <Account> GetByLogin(string name, string password)
        {
            return new[] { container.GetByLogin(name, password) };
        }

        [HttpPut(Name = "Register/{name}/{password}")]
        public IEnumerable<bool> Register(string name, string password)
        {
            return new[] { container.Create(new Account(0, name, password)) };
        }
    }
}
