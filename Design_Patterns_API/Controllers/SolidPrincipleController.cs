using Design_Patterns.SOLID;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Design_Patterns_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolidPrincipleController : ControllerBase
    {
        private readonly ILogger<SolidPrincipleController> _logger;
        private readonly SingleResponsibilty _singleResponsibilty;
        private readonly OpenClosed _openClosed;

        public SolidPrincipleController(ILogger<SolidPrincipleController> logger, SingleResponsibilty singleResponsibilty, OpenClosed openClosed)
        {
            _logger = logger;
            _singleResponsibilty = singleResponsibilty;
            _openClosed = openClosed;
        }

        [HttpGet]
        [Route("srp")]
        public ActionResult SingleResponsibility()
        {
            _logger.LogInformation("Executing Single Responsibilty.");
            var respone = _singleResponsibilty.GetFruits();
            return Ok(respone);
        }

        [HttpGet()]
        [Route("ocp")]
        public ActionResult OpenClosed()
        {
            _logger.LogInformation("Executing Single OpenClosed.");
            var respone = _openClosed.GetHost();
            return Ok(respone);
        }
    }
}
