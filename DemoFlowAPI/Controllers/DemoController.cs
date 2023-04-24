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
            // Return a no content responseinste
            return Ok("Deleted");
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody]DemoData data)
        {
            Console.WriteLine("A request has been recieved: " + data);
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

        [HttpPost]
        public IActionResult Save(DemoObject demoObject)
        {
            var result=demoContainer.SaveDemo(demoObject);  
            return Ok(result);
        }
        
        public class DemoData
        {
            public int AccountId { get; set; }
            public string DemoName { get; set; }
        }
    }
}