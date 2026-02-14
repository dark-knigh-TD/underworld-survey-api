using SurveyApi.Model;

namespace SurveyApi.Services
{
    public interface IServiceUser
    {
        Task<IEnumerable<UserSurvey>> GetAllUsersAsync();
        Task<UserSurvey?> GetUserByIdAsync(int id);
        Task<int> CreateUserAsync(UserSurvey user);
        Task<bool> UpdateUserAsync(UserSurvey user);
        Task<bool> DeleteUserAsync(int id);
    }
}