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
        private readonly FacadePattern _facadePattern;
        private readonly DecoratorPattern _decoratorPattern;

        public StructuralPatternController(ILogger<StructuralPatternController> logger, AdapterPattern adapterPattern, FacadePattern facadePattern, DecoratorPattern decoratorPattern)
        {
            _logger = logger;
            _adapterPattern = adapterPattern;
            _facadePattern = facadePattern;
            _decoratorPattern = decoratorPattern;
        }


        [HttpGet]
        [Route("adapter")]
        public ActionResult CheckAdapter()
        {
            _logger.LogInformation("Executing adapter pattern.");
            var respone = _adapterPattern.CheckActiveSocket();
            return Ok(respone);
        }

        [HttpGet]
        [Route("facade")]
        public ActionResult CheckFacade()
        {
            _logger.LogInformation("Executing facade pattern.");
            var respone = _facadePattern.CheckOrderManagement();
            return Ok(respone);
        }

        [HttpGet]
        [Route("decorator")]
        public ActionResult CheckDecorator()
        {
            _logger.LogInformation("Executing decorator pattern.");
            var respone = _decoratorPattern.SaveChanges();
            return Ok(respone);
        }
    }
}
