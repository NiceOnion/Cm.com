using BusinessLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace DemoFlowAPI.Controllers
{
    [ApiController]
    [Route("api/Demo/{demoId}/[controller]")]
    public class FlowController : ControllerBase
    {
        private readonly ILogger<FlowController> _logger;
        private readonly DemoDAL demoDAL = new DemoDAL();
        private DemoObject currentDemo;
        public FlowController()
        {
        }
        //all functions must contain (int demoId)

        [HttpGet("{flowId}")]
        public Flow Get(int demoId, int flowId)
        {
            var democontainer = new DemoContainer(demoDAL);
            var currentFlow = democontainer.GetOneDemoObject(demoId).GetFlow(new FlowDAL(), flowId);

            return currentFlow;
        }

        //[HttpPost("Create")]
        //public IActionResult Create([FromBody]Flow newFlow)
        //{
        //    var result = 
        //    return Ok(result);
        //} 

        [HttpPut("{flowId}/Edit")]
        public IActionResult Edit(int demoId, int flowId, [FromBody]Flow flow)
        {
            if (flow.Id != flowId) return Conflict("Flow ids do not match.");
            var democontainer = new DemoContainer(demoDAL);
            
            var result = flow.Edit(new FlowDAL());
            if (result)
            {
                return Ok(result);
            } else
            {
                return BadRequest(result);
            }
        } 
    }
}
