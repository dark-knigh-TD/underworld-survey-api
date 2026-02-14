using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApi.Model
{
    public class UserSurvey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; } 
        public DateTime CreatedAt { get; set; } 
    }
}