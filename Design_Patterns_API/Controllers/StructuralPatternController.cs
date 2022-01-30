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

        public StructuralPatternController(ILogger<StructuralPatternController> logger, AdapterPattern adapterPattern, FacadePattern facadePattern)
        {
            _logger = logger;
            _adapterPattern = adapterPattern;
            _facadePattern = facadePattern;
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
    }
}
