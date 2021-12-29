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
        private readonly LiskovSubstitution _liskovSubstitution;

        public SolidPrincipleController(ILogger<SolidPrincipleController> logger, SingleResponsibilty singleResponsibilty, OpenClosed openClosed, LiskovSubstitution liskovSubstitution)
        {
            _logger = logger;
            _singleResponsibilty = singleResponsibilty;
            _openClosed = openClosed;
            _liskovSubstitution = liskovSubstitution;
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
            _logger.LogInformation("Executing OpenClosed.");
            var respone = _openClosed.GetHost();
            return Ok(respone);
        }

        [HttpGet()]
        [Route("lsp")]
        public ActionResult LiskovSubstitution()
        {
            _logger.LogInformation("Executing OpenClosed.");
            var respone = _liskovSubstitution.GetGrocery();
            return Ok(respone);
        }
    }
}
