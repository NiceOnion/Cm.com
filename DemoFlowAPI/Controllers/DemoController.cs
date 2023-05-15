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

        [HttpGet("SingleByName/{name}", Name = "GetDemoByName")]
        public DemoObject GetDemoByName(string name)
        {
            return demoContainer.GetOneDemoObjectByName(name);
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
            var result = demoContainer.DeleteDemo(id);
            // Return a no content response
            if (result == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult EditDemo(int id, DemoObject demoobject)
        {

            // Check if the provided ID matches the ID of the demo object in the request body
            if (id != demoobject.Id)
            {
                return BadRequest();
            }

            // Try to update the demo object in the database
            bool result = demoContainer.EditDemo(demoobject.Id);
            if (result) return Ok(result);
            else return NoContent();
        }

        [HttpPost("add")]
        public IActionResult AddDemo([FromBody]DemoObject demoObject)
        {
            if( demoContainer.NewDemoObject(demoObject)) return Ok(demoObject);
            else return BadRequest();
        }

        [HttpPost]
        public IActionResult Save(DemoObject demoObject)
        {
            var result = demoContainer.SaveDemo(demoObject);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}