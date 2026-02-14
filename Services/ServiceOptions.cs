using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyApi.Model;
using SurveyApi.Repositories;

namespace SurveyApi.Services
{
    public class ServiceOptions : IServiceOptions
    {
        ILogger<OptionsSurvey> _logger;
        IConfiguration _configuration;
        IRepository<OptionsSurvey> _repositoryOptionsSurvey;
        public ServiceOptions(ILogger<OptionsSurvey> logger, IConfiguration configuration, IRepository<OptionsSurvey> repositoryOptionsSurvey)
        {
            _logger = logger;
            _configuration = configuration;
            _repositoryOptionsSurvey = repositoryOptionsSurvey;
        }
        


        public Task<IEnumerable<OptionsSurvey>> GetAllOptionsSurveyAsync()
        {
            return Task.FromResult<IEnumerable<OptionsSurvey>>(_repositoryOptionsSurvey.GetAll().ToList());
        }
        public Task<OptionsSurvey> GetOptionsSurveyByIdAsync(int surveyId)
        {

            return Task.FromResult(_repositoryOptionsSurvey.GetById(surveyId));
        }

        public Task<int> CreateOptionsSurveyAsync(OptionsSurvey optionsSurvey)
        {
             _repositoryOptionsSurvey.Add(optionsSurvey);
            return Task.FromResult(optionsSurvey.OptionId);
        }


        public Task<bool> UpdateOptionsSurveyAsync(OptionsSurvey optionsSurvey)
        {
            _repositoryOptionsSurvey.Update(optionsSurvey);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteOptionsSurveyAsync(int surveyId)
        {
            _repositoryOptionsSurvey.Delete(surveyId);
            return Task.FromResult(true);
        }

        
    }
       
}