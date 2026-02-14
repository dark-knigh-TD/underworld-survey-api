using SurveyApi.Model;

namespace SurveyApi.Services
{
    public interface IServiceMultipleResponses
    {
        Task<IEnumerable<MultipleResponses>> GetAllMultipleResponsesAsync();
        Task<MultipleResponses?> GetMultipleResponsesByIdAsync(int id);
        Task<int> CreateMultipleResponsesAsync(MultipleResponses survey);
        Task<bool> UpdateMultipleResponsesAsync(MultipleResponses survey);
        Task<bool> DeleteMultipleResponsesAsync(int id);
    }
}