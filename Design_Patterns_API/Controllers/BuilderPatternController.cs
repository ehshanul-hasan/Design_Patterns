using Design_Patterns;
using Design_Patterns.SOLID;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Design_Patterns_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuilderPatternController : ControllerBase
    {
        private readonly ILogger<SolidPrincipleController> _logger;
        private readonly BuilderPattern _builderPattern;

        public BuilderPatternController(ILogger<SolidPrincipleController> logger, BuilderPattern builderPattern)
        {
            _logger = logger;
            _builderPattern = builderPattern;
        }

        [HttpGet]
        [Route("fluentBuilder")]
        public ActionResult CheckBuilder()
        {
            _logger.LogInformation("Executing builder pattern.");
            var respone = _builderPattern.GetSubscription();
            return Ok(respone);
        }
    }
}
