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
        [RegularExpression(@"^(\+4|)?(07[0-8]{1}[0-9]{1}|02[0-9]{2}|03[0-9]{2}){1}?(\s|\.|\-)?([0-9]{3}(\s|\.|\-|)){2}$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
    }
}