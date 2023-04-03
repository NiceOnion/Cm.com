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

        [HttpPost("/add/{id}")]
        public IActionResult Add([FromBody]DemoData data)
        {
            try
            {
                demoContainer.NewDemoObject(new DemoDTO(data.DemoName));
                return Ok("Added");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        public class DemoData
        {
            public int AccountId { get; set; }
            public string DemoName { get; set; }
        }
    }
}
