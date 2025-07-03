using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Speedy_Groceries.Models
{
    public class LoginInfo
    {
        [ValidateNever]
        public int? loginuid { get; set; }


        [Required(ErrorMessage = "*Please enter your email.")]
        [EmailAddress(ErrorMessage = "*Invalid email address.")]
        [DataType(DataType.EmailAddress)]
        public string? Loginemail { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "*Please enter the password.")]
        
        public string? Loginpassword { get; set; }
    }
}
