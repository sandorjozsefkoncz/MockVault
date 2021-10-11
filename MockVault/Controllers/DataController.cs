using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MockVault.Controllers
{
    [ApiController]
    [Route("/v1/appservices/data/{**secretPath}")]
    public class DataController : ControllerBase
    {
        private readonly VaultService _service;

        public DataController(VaultService service)
        {           
            _service = service;
        }

        [HttpGet]
        public IActionResult Get([FromRoute]string secretPath)
        {
            var secret = _service.Get(secretPath);
            if (secret is null)
                return NotFound();

            var ro = new GetVaultDataResponse()
            {
                Data = new Data()
                {
                    AccessKeyData = new AccessKeyData()
                    {
                        AccessKey = secret
                    }
                }
            };

            return Ok(ro);
        }

        [HttpPut]
        public IActionResult Put([FromRoute] string secretPath,[FromBody] Data vaultSecret )
        {
            _service.Add(secretPath, vaultSecret.AccessKeyData.AccessKey);

            return Ok();
        }
    }
}
