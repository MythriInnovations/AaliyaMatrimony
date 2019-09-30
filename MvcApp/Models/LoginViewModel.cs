using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email address is manadatory")]
        [EmailAddress(ErrorMessage ="Please put a valid email address")]
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Password is manadatory")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
