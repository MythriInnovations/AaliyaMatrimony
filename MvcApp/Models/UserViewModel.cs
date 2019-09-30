using System.ComponentModel.DataAnnotations;
namespace MvcApp.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Username is mandatory")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is mandatory")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is mandatory")]
        [Compare("Password", ErrorMessage = "Password and ConfirmPassword do not match")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress(ErrorMessage ="Please use a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mobile number is mandatory")]
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Id { get; set; }
    }
}