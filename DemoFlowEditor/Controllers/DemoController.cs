using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc.Formatters;
using DataAccessLayer;

namespace DemoFlowEditor.Controllers
{
    [ApiController]
    [Route("Demo")]
    public class DemoController : ControllerBase
    {

        private readonly ILogger<DemoController> _logger;

        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<DemoObject> Get()
        {
            DemoContainer demoContainer = new DemoContainer(new DemoDAL());
            return demoContainer.GetAllDemo();
        }
    }
}
