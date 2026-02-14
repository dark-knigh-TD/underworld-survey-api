using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SurveyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AzureController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AzureController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("message")]
        public IActionResult GetMessageAzure()
        {
            var message = _configuration["AzureMessage"] ?? "Hello from Azure";
            return Ok(new { message });
        }
    }
}