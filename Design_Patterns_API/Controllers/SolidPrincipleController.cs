using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Design_Patterns_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolidPrincipleController : ControllerBase
    {
        private readonly ILogger<SolidPrincipleController> _logger;

        public SolidPrincipleController(ILogger<SolidPrincipleController> logger)
        {
            _logger = logger;
        }
    }
}
