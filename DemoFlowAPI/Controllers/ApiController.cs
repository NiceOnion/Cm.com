using Microsoft.AspNetCore.Mvc;

namespace DemoFlowAPI.Controllers
{
    public class ApiController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public ApiController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
    }
}
