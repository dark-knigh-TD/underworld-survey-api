using SurveyApi.Model;

namespace SurveyApi.Services
{
    public interface IServiceSurvey
    {
        Task<IEnumerable<Survey>> GetAllSurveysAsync();
        Task<Survey?> GetSurveyByIdAsync(int id);
        Task<int> CreateSurveyAsync(Survey survey);
        Task<bool> UpdateSurveyAsync(Survey survey);
        Task<bool> DeleteSurveyAsync(int id);
    }
}