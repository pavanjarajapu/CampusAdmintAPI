using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StuAdmit.Controllers
{
    [Route("api/Test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Hey,this is a an INFO message");
            _logger.LogWarning("Hey,this is a an WARNING message");
            _logger.LogError("Hey,this is a an ERROR message");
            _logger.LogCritical("Hey,this is a an CRITICAL message");
            return Ok();
        }
    }
}
