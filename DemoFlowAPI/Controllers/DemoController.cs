using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;

namespace DemoFlowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;
        private readonly DemoContainer demoContainer;
        public DemoController()
        {
            demoContainer = new DemoContainer(new DemoDAL());
        }

        [HttpGet("Single/{id}", Name = "GetDemos")]
        public DemoObject GetDemo(int id)
        {
            return demoContainer.GetOneDemoObject(id);
        }

        [HttpGet("{userId}")]
        public List<DemoObject> GetDemosOfUser(int userId)
        {
            return demoContainer.GetDemosOfUser(userId);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Delete the resource
            var deleteddemo = demoContainer.DeleteDemo(id);
            // Return a no content response
            return Ok("Deleted");
    }
        }
    }
}