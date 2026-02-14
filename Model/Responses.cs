using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApi.Model
{
    public class Responses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResponseId { get; set; } 
        public int QuestionId { get; set; } 
        public int UserId { get; set; } 
        public string ResponseText { get; set; } 
        public DateTime CreatedAt { get; set; } 

        // Propiedades de navegación opcionales
        public Question Question { get; set; }
        public UserSurvey User { get; set; }
    }
}