using Microsoft.AspNetCore.Mvc;
using SurveyApi.Model.Request;
using SurveyApi.Model.Response;
using SurveyApi.Services;

namespace SurveyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly ILogger<SurveyController> _logger;
        IServiceManageSurvey _serviceMangeSurvey;
        public SurveyController(ILogger<SurveyController> logger, IServiceManageSurvey serviceMangeSurvey)
        {
            _logger = logger;
            _serviceMangeSurvey = serviceMangeSurvey;

        }
        
        [HttpGet]
        public IActionResult GetSurveys()
        {
            // Placeholder for retrieving surveys
            return Ok(new { Message = "List of surveys" });
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetSurveyById(int id)
        {
            // Placeholder for retrieving a survey by ID
            return Ok(new { Message = $"Survey with ID {id}" });
        }

        [HttpPost("Create")]
        public Task<ResponseSurvey> CreateSurvey(RequestSurvey survey)
        {
            // Placeholder for creating a new survey
            return _serviceMangeSurvey.CreateSurvey(survey);
        }

        [HttpPut("Update/{id}")]
        public Task<ResponseSurvey> UpdateSurvey(RequestSurvey survey)
        {
            // Placeholder for updating a survey
            return _serviceMangeSurvey.UpdateSurvey(survey);
        }

        [HttpDelete("Delete/{id}")]
        public Task<ResponseSurvey> DeleteSurvey(int id)
        {
            // Placeholder for deleting a survey
            return _serviceMangeSurvey.DeleteSurvey(id);
        }
    }
}