using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyApi.Model;
using SurveyApi.Repositories;

namespace SurveyApi.Services
{
    public class ServiceQuestion : IServiceQuestion
    {
        ILogger<Question> _logger;
        IConfiguration _configuration;
        IRepository<Question> _repositoryQuestion;
        public ServiceQuestion(ILogger<Question> logger, IConfiguration configuration, IRepository<Question> repositoryQuestion)
        {
            _logger = logger;
            _configuration = configuration;
            _repositoryQuestion = repositoryQuestion;
        }


        public Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return Task.FromResult<IEnumerable<Question>>(_repositoryQuestion.GetAll().ToList());
        }
        public Task<Question> GetQuestionByIdAsync(int surveyId)
        {

            return Task.FromResult(_repositoryQuestion.GetById(surveyId));
        }

        public Task<int> CreateQuestionAsync(Question question)
        {
             _repositoryQuestion.Add(question);
            return Task.FromResult(question.QuestionId);
        }


        public Task<bool> UpdateQuestionAsync(Question question)
        {
            _repositoryQuestion.Update(question);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteQuestionAsync(int surveyId)
        {
            _repositoryQuestion.Delete(surveyId);
            return Task.FromResult(true);
        }

        
    }
       
}