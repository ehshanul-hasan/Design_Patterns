using Design_Patterns;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Design_Patterns_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BehavioralPatternController : ControllerBase
    {
        private readonly ILogger<StructuralPatternController> _logger;
        private readonly ObeserverPattern _observable;

        public BehavioralPatternController(ILogger<StructuralPatternController> logger, ObeserverPattern observable)
        {
            _logger = logger;
            _observable = observable;
        }


        [HttpGet]
        [Route("observer")]
        public ActionResult CheckObserver()
        {
            _logger.LogInformation("Executing observer pattern.");
            var respone = _observable.GetStockUpdates();
            return Ok(respone);
        }

    }
}
