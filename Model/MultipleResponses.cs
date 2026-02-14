using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApi.Model
{
    public class MultipleResponses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MultiResponseId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        [ForeignKey("Option")]
        public int OptionId { get; set; }

        public DateTime RespondedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual UserSurvey User { get; set; }
        public virtual Question Question { get; set; }
        public virtual OptionsSurvey Option { get; set; }
    }
}