using SurveyApi.Model;

namespace SurveyApi.Services
{
    public interface IServiceOptions
    {
         Task<IEnumerable<OptionsSurvey>> GetAllOptionsSurveyAsync();
        Task<OptionsSurvey?> GetOptionsSurveyByIdAsync(int id);
        Task<int> CreateOptionsSurveyAsync(OptionsSurvey question);
        Task<bool> UpdateOptionsSurveyAsync(OptionsSurvey question);
        Task<bool> DeleteOptionsSurveyAsync(int id);
    }
}