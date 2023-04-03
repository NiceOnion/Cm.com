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
        DemoContainer demoContainer = new DemoContainer(new DemoDAL());


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
