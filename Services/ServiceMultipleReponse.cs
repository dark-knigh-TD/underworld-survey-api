using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyApi.Model;
using SurveyApi.Repositories;

namespace SurveyApi.Services
{
    public class ServiceMultipleResponses : IServiceMultipleResponses
    {
        ILogger<MultipleResponses> _logger;
        IConfiguration _configuration;
        IRepository<MultipleResponses> _repositoryMultipleResponses;
        public ServiceMultipleResponses(ILogger<MultipleResponses> logger, IConfiguration configuration, IRepository<MultipleResponses> repositoryMultipleResponses)
        {
            _logger = logger;
            _configuration = configuration;
            _repositoryMultipleResponses = repositoryMultipleResponses;
        }


        public Task<IEnumerable<MultipleResponses>> GetAllMultipleResponsesAsync()
        {
            return Task.FromResult<IEnumerable<MultipleResponses>>(_repositoryMultipleResponses.GetAll().ToList());
        }
        public Task<MultipleResponses> GetMultipleResponsesByIdAsync(int multipleResponsesId)
        {

            return Task.FromResult(_repositoryMultipleResponses.GetById(multipleResponsesId));
        }

        public Task<int> CreateMultipleResponsesAsync(MultipleResponses multipleResponses)
        {
             _repositoryMultipleResponses.Add(multipleResponses);
            return Task.FromResult(multipleResponses.MultiResponseId);
        }


        public Task<bool> UpdateMultipleResponsesAsync(MultipleResponses multipleResponses)
        {
            _repositoryMultipleResponses.Update(multipleResponses);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteMultipleResponsesAsync(int multipleResponsesId)
        {
            _repositoryMultipleResponses.Delete(multipleResponsesId);
            return Task.FromResult(true);
        }

        
    }
       
}