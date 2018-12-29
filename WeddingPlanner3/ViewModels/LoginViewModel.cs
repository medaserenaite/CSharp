using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner3.ViewModels {
    public class LoginViewModel {

        [Required(ErrorMessage = "Required Field")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}