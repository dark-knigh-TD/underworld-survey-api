using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApi.Model
{
    public class Survey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SurveyId { get; set; } 
        public string Title { get; set; } 
        public string Description { get; set; } 
        public DateTime CreatedAt { get; set; } 
    }
}