using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApi.Model
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; } 
        public int SurveyId { get; set; } 
        public string QuestionText { get; set; } 
        public string QuestionType { get; set; } 
        public bool IsRequired { get; set; } 
        public int QuestionOrder { get; set; } 

        // Propiedad de navegación opcional para la relación con Survey
        public Survey Survey { get; set; }

    }
}