using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyApi.Model;
using SurveyApi.Repositories;

namespace SurveyApi.Services
{
    public class ServiceResponses : IServiceResponses
    {
        ILogger<Responses> _logger;
        IConfiguration _configuration;
        IRepository<Responses> _repositoryResponses;
        public ServiceResponses(ILogger<Responses> logger, IConfiguration configuration, IRepository<Responses> repositoryResponses)
        {
            _logger = logger;
            _configuration = configuration;
            _repositoryResponses = repositoryResponses;
        }
        public Task<Responses> GetResponsesByIdAsync(int id)
        {
            return Task.FromResult(_repositoryResponses.GetById(id));
        }
        public Task<IEnumerable<Responses>> GetAllResponsesAsync()
        {
            return Task.FromResult<IEnumerable<Responses>>(_repositoryResponses.GetAll().ToList());
        }
        public Task<int> CreateResponsesAsync(Responses responses)
        {
            _repositoryResponses.Add(responses);
            return Task.FromResult(responses.ResponseId);
        }
        public Task<bool> UpdateResponsesAsync(Responses responses)
        {
            _repositoryResponses.Update(responses);
            return Task.FromResult(true);
        }
        public Task<bool> DeleteResponsesAsync(int surveyId)
        {
            _repositoryResponses.Delete(surveyId);
            return Task.FromResult(true);
        }
        
    }
       
}