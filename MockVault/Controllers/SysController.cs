using Microsoft.AspNetCore.Mvc;

namespace MockVault.Controllers
{
    [ApiController]
    [Route("v1/sys/")]
    public class SysController : ControllerBase
    {
        [HttpGet]
        [Route("health")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
