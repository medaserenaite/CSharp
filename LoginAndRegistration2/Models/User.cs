using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginAndRegistration2.Models
{
    public class User
    {
        [Key]
        public int userID { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Required Field")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Required Field")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}