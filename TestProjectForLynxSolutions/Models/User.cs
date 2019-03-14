using System.ComponentModel.DataAnnotations;

namespace TestProjectForLynxSolutions.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "The username is required")]
        [StringLength(255)]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "The password is required")]
        [StringLength(255)]        
        public string Password { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "The first name is required")]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "The last name is required")]
        [StringLength(255)]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [StringLength(255)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"/^(?:(?:(?:00\s?|\+)40\s?|0)(?:7\d{2}\s?\d{3}\s?\d{3}|(21|31)\d{1}\s?\d{3}\s?\d{3}|((2|3)[3-7]\d{1})\s?\d{3}\s?\d{3}|(8|9)0\d{1}\s?\d{3}\s?\d{3}))$/", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
    }
}