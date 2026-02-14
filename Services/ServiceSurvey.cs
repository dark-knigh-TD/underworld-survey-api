using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyApi.Context;
using SurveyApi.Model;
using SurveyApi.Repositories;

namespace SurveyApi.Services
{
    public class ServiceSurvey : IServiceSurvey
    {
        ILogger<Survey> _logger;
        IConfiguration _configuration;
        IRepository<Survey> _repositorySurvey;

             public ServiceSurvey(ILogger<Survey> logger, IConfiguration configuration, IRepository<Survey> repositorySurvey)
        {
            _logger = logger;
            _configuration = configuration;
            _repositorySurvey = repositorySurvey;
        }


        public Task<IEnumerable<Survey>> GetAllSurveysAsync()
        {
            return Task.FromResult<IEnumerable<Survey>>(_repositorySurvey.GetAll().ToList());
        }
        public Task<Survey> GetSurveyByIdAsync(int surveyId)
        {

            return Task.FromResult(_repositorySurvey.GetById(surveyId));
        }

        public Task<int> CreateSurveyAsync(Survey survey)
        {
             _repositorySurvey.Add(survey);
            
            return Task.FromResult(survey.SurveyId);
        }


        public Task<bool> UpdateSurveyAsync(Survey survey)
        {
            _repositorySurvey.Update(survey);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteSurveyAsync(int surveyId)
        {
            _repositorySurvey.Delete(surveyId);
            return Task.FromResult(true);
        }

        
    }
       
}