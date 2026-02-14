using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyApi.Model;
using SurveyApi.Repositories;

namespace SurveyApi.Services
{
    public class ServiceUser: IServiceUser
    {
        ILogger<ServiceUser> _logger;
        IConfiguration _configuration;
        IRepository<UserSurvey> _repositoryUser;
        public ServiceUser(ILogger<ServiceUser> logger, IConfiguration configuration, IRepository<UserSurvey> repositoryUser)
        {
            _logger = logger;
            _configuration = configuration;
            _repositoryUser = repositoryUser;
        }

        public Task<UserSurvey> GetUserByIdAsync(int userId)
        {
           
           return Task.FromResult(_repositoryUser.GetById(userId));
        }

        
        public Task<IEnumerable<UserSurvey>> GetAllUsersAsync()
        {
           
           return Task.FromResult<IEnumerable<UserSurvey>>(_repositoryUser.GetAll().ToList());
        }

       
        public Task<int> CreateUserAsync(UserSurvey user)
        {
            _repositoryUser.Add(user);
            return Task.FromResult(user.UserId);
        }
    
        public Task<bool> UpdateUserAsync(UserSurvey user)
        {
           _repositoryUser.Update(user);
            return Task.FromResult(true);
        }
        
        public Task<bool> DeleteUserAsync(int userId)
        {
            _repositoryUser.Delete(userId);
            return Task.FromResult(true);
        }
    }

   
}