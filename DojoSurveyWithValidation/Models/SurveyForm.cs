using System.ComponentModel.DataAnnotations;

namespace DojoSurveyWithValidation.Models
{
    public class SurveyForm
    {
        [Required(ErrorMessage="Name cannot be empty")]
        [MinLength(2, ErrorMessage="Name must be at least 2 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage="Location cannot be empty")]
        public string Location { get; set; }
        
        [Required(ErrorMessage="Language cannot be empty")]
        public string Language { get; set; }
      
        [MaxLength(20)]
        public string Comment { get; set; }
    }
}