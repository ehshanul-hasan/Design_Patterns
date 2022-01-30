using Design_Patterns;
using Design_Patterns.SOLID;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Design_Patterns_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreationalPatternController : ControllerBase
    {
        private readonly ILogger<SolidPrincipleController> _logger;
        private readonly BuilderPattern _builderPattern;
        private readonly SingletonChecker _singletonChecker;
        private readonly FactoryPattern __factoryPattern;

        public CreationalPatternController(ILogger<SolidPrincipleController> logger, BuilderPattern builderPattern, SingletonChecker singletonChecker, FactoryPattern factoryPattern)
        {
            _logger = logger;
            _builderPattern = builderPattern;
            _singletonChecker = singletonChecker;
            __factoryPattern = factoryPattern;
        }

        [HttpGet]
        [Route("fluentBuilder")]
        public ActionResult CheckBuilder()
        {
            _logger.LogInformation("Executing builder pattern.");
            var respone = _builderPattern.GetSubscription();
            return Ok(respone);
        }

        [HttpGet]
        [Route("singleton")]
        public ActionResult CheckSingleton()
        {
            _logger.LogInformation("Executing singleton pattern.");
            var respone = _singletonChecker.GetIP();
            return Ok(respone);
        }

        [HttpGet]
        [Route("factory")]
        public ActionResult CheckFactory()
        {
            _logger.LogInformation("Executing factory pattern.");
            var respone = __factoryPattern.GetYougurt();
            return Ok(respone);
        }
    }
}
