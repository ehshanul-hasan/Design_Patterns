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
        private readonly InterfaceSegregation _interfaceSegregation;
        private readonly DependencyInversion _dependencyInversion;

        public SolidPrincipleController(ILogger<SolidPrincipleController> logger, SingleResponsibilty singleResponsibilty, OpenClosed openClosed, LiskovSubstitution liskovSubstitution, InterfaceSegregation interfaceSegregation, DependencyInversion dependencyInversion)
        {
            _logger = logger;
            _singleResponsibilty = singleResponsibilty;
            _openClosed = openClosed;
            _liskovSubstitution = liskovSubstitution;
            _interfaceSegregation = interfaceSegregation;
            _dependencyInversion = dependencyInversion;
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
            _logger.LogInformation("Executing LiskovSubstitution.");
            var respone = _liskovSubstitution.GetGrocery();
            return Ok(respone);
        }

        [HttpGet()]
        [Route("isp")]
        public ActionResult InterfaceSegregation()
        {
            _logger.LogInformation("Executing InterfaceSegregation.");
            var respone = _interfaceSegregation.SendMessageByMobileNetwork();
            return Ok(respone);
        }

        [HttpGet()]
        [Route("dpp")]
        public ActionResult DependencyInversion()
        {
            _logger.LogInformation("Executing DependencyInversion.");
            var respone = _dependencyInversion.DevServerCount();
            return Ok(respone);
        }
    }
}
