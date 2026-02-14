using SurveyApi.Model;

namespace SurveyApi.Services
{
    public interface IServiceResponses
    {
        Task<Responses> GetResponsesByIdAsync(int id);
        Task<IEnumerable<Responses>> GetAllResponsesAsync();
        Task<int> CreateResponsesAsync(Responses response);
        Task<bool> UpdateResponsesAsync(Responses response);
        Task<bool> DeleteResponsesAsync(int id);
    }
}