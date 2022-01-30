using Design_Patterns;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Design_Patterns_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StructuralPatternController : ControllerBase
    {
        private readonly ILogger<StructuralPatternController> _logger;
        private readonly AdapterPattern _adapterPattern;

        public StructuralPatternController(ILogger<StructuralPatternController> logger, AdapterPattern adapterPattern)
        {
            _logger = logger;
            _adapterPattern = adapterPattern;
        }


        [HttpGet]
        [Route("adapter")]
        public ActionResult CheckAdapter()
        {
            _logger.LogInformation("Executing adapter pattern.");
            var respone = _adapterPattern.CheckActiveSocket();
            return Ok(respone);
        }
    }
}
