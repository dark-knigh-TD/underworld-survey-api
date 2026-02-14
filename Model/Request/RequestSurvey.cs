namespace SurveyApi.Model.Request
{
    public class RequestSurvey
    {
        public Survey survey { get; set; }
        public List<Question> questions { get; set; }
        public List<OptionsSurvey> options { get; set; }
        
        
    }
}