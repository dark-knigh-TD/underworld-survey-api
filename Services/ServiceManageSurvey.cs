
using AutoMapper;
using SurveyApi.Model;
using SurveyApi.Model.Request;
using SurveyApi.Model.Response;
using SurveyApi.Services.Profile;
using Newtonsoft.Json;
using System.Linq;


namespace SurveyApi.Services
{
    public class ServiceManageSurvey : IServiceManageSurvey
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ServiceManageSurvey> _logger;
        private readonly IMapper _mapper;
        private readonly IServiceSurvey _serviceSurvey;
        private readonly IServiceQuestion _serviceQuestion;
        private readonly IServiceOptions _serviceOptions;
        public ServiceManageSurvey(ILogger<ServiceManageSurvey> logger, IConfiguration configuration, IServiceSurvey serviceSurvey, IServiceQuestion serviceQuestion, IServiceOptions serviceOptions)
        {
            _mapper = ApplicationProfile.ConfigMaps();
            _serviceSurvey = serviceSurvey;
            _serviceQuestion = serviceQuestion;
            _serviceOptions = serviceOptions;

            _logger = logger;
            _configuration = configuration;

        }
        public async Task<ResponseSurvey> CreateSurvey(RequestSurvey survey)
        {
            ResponseSurvey responseSurvey = new ResponseSurvey();

            //var objSurvey = JsonConverter.DeserializeObject<RequestSurvey>(survey);
            //reqSurvey = _mapper.Map<RequestSurvey, Survey>(survey);
            Survey reqSurvey = survey.survey;
            List<Question> reqQuestion = survey.questions;
            List<OptionsSurvey> reqOptions = survey.options;

            int surveyId = 0;
            int optionId = 0;
            int questionId = 0;
            // Guardar la encuesta
            surveyId = await _serviceSurvey.CreateSurveyAsync(reqSurvey);

            // Guardar las preguntas
            foreach (var question in reqQuestion)
            {
                question.SurveyId = surveyId;
                questionId = await _serviceQuestion.CreateQuestionAsync(question);

            }

            // Guardar las opciones
            foreach (var option in reqOptions)
            {
                option.QuestionId = questionId;
                optionId = await _serviceOptions.CreateOptionsSurveyAsync(option);

            }
            return new ResponseSurvey
            {
                Success = true,
                Message = "Survey created successfully",
                SurveyId = surveyId,

            };

        }


        public async Task<ResponseSurvey> UpdateSurvey(RequestSurvey survey)
        {
            ResponseSurvey responseSurvey = new ResponseSurvey();
            Survey reqSurvey = survey.survey;
            List<Question> reqQuestion = survey.questions;
            List<OptionsSurvey> reqOptions = survey.options;   

            // Edita la encuesta
            await _serviceSurvey.UpdateSurveyAsync(reqSurvey);

            // Edita las preguntas
            foreach (var question in reqQuestion)
            {
                await _serviceQuestion.UpdateQuestionAsync(question);
            }
            // Edita las opciones
            foreach (var option in reqOptions)
            {
                await _serviceOptions.UpdateOptionsSurveyAsync(option);
            }

            return new ResponseSurvey
            {
                Success = true,
                Message = "Survey edited successfully",
                SurveyId = reqSurvey.SurveyId,

            };
        }
        

        public async Task<ResponseSurvey> DeleteSurvey(int id)
        {
            ResponseSurvey responseSurvey = new ResponseSurvey();


            Survey reqSurvey = await _serviceSurvey.GetSurveyByIdAsync(id);
            List<Question> reqQuestion =  _serviceQuestion.GetAllQuestionsAsync().Result.Where(x => x.SurveyId == id).ToList();
            //List<OptionsSurvey> reqOptions = _serviceOptions.GetAllOptionsSurveyAsync().Result.Where(x => x.QuestionId == id).ToList();

            // Elimina preguntas y opciones    
            foreach (var question in reqQuestion)
            {
                List<OptionsSurvey> reqOptions =  _serviceOptions.GetAllOptionsSurveyAsync().Result.Where(x => x.QuestionId == question.QuestionId).ToList();
                foreach (var option in reqOptions)
                {
                    await _serviceOptions.DeleteOptionsSurveyAsync(option.OptionId);
                }

                await _serviceOptions.DeleteOptionsSurveyAsync(question.SurveyId);
            }
        
            // Elimina la encuesta
            await _serviceSurvey.DeleteSurveyAsync(id);

            return new ResponseSurvey
            {
                Success = true,
                Message = "Survey edited successfully",
                SurveyId = id,

            };
        }

    }
}