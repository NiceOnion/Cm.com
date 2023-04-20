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

        [HttpPut("{id}")]
        public IActionResult EditDemo(int id, DemoObject demoobject)
        {
            // Check if the provided ID matches the ID of the demo object in the request body
            if (id != demoobject.id)
            {
                return BadRequest();
            }

            // Try to update the demo object in the database
            bool result = demoContainer.EditDemo(demoobject);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
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
