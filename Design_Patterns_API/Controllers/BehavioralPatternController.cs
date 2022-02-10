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
        private readonly StrategyPattern _strategyPattern;
        private readonly MediatorPattern _mediatorPattern;

        public BehavioralPatternController(ILogger<StructuralPatternController> logger, ObeserverPattern observable, StrategyPattern strategyPattern, MediatorPattern mediatorPattern)
        {
            _logger = logger;
            _observable = observable;
            _strategyPattern = strategyPattern;
            _mediatorPattern = mediatorPattern;
        }


        [HttpGet]
        [Route("observer")]
        public ActionResult CheckObserver()
        {
            _logger.LogInformation("Executing observer pattern.");
            var respone = _observable.GetStockUpdates();
            return Ok(respone);
        }

        [HttpGet]
        [Route("strategy")]
        public ActionResult CheckStrategy()
        {
            _logger.LogInformation("Executing strategy pattern.");
            var respone = _strategyPattern.GetFormattedReponse();
            return Ok(respone);
        }

        [HttpGet]
        [Route("mediator")]
        public ActionResult CheckMediator()
        {
            _logger.LogInformation("Executing Mediator pattern.");
            var respone = _mediatorPattern.GetChatHistory();
            return Ok(respone);
        }

    }
}
