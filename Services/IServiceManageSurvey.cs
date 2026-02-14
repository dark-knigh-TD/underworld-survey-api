using SurveyApi.Model.Request;
using SurveyApi.Model.Response;

namespace SurveyApi.Services
{
    public interface IServiceManageSurvey
    {

        Task<ResponseSurvey> CreateSurvey(RequestSurvey survey);
        Task<ResponseSurvey> UpdateSurvey(RequestSurvey survey);
        Task<ResponseSurvey> DeleteSurvey(int id);
        
    }
}