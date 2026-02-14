using AutoMapper;
using SurveyApi.Model;
using SurveyApi.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Services.Profile
{
    public static class ApplicationProfile
    {
        public static IMapper ConfigMaps()
        {
            var config = new MapperConfiguration(cfg =>
            {
                
                cfg.CreateMap<RequestSurvey, Survey>();
                cfg.CreateMap<Survey, RequestSurvey>();
                

            });
            return config.CreateMapper();
        }
    }
}
