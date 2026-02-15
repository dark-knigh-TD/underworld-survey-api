using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SurveyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AzureController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SecretClient _secretClient;
        public AzureController(IConfiguration configuration, SecretClient secretClient)
        {
            _configuration = configuration;
            _secretClient = secretClient;
        }

        [HttpGet("message")]
        public IActionResult GetMessageAzure()
        {
            var message = _configuration["AzureMessage"] ?? "Hello from Azure";
            return Ok(new { message });
        }


        [HttpGet("{secretName}")]
        public async Task<IActionResult> GetSecret(string secretName)
        {
            try
            {
                KeyVaultSecret secret = await _secretClient.GetSecretAsync(secretName);

                return Ok(new
                {
                    name = secret.Name,
                    value = secret.Value
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error obteniendo secret: {ex.Message}");
            }
        }

    }

 

}


