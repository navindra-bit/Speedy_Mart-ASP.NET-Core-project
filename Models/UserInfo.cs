using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Speedy_Groceries.Models
{
    public class UserInfo
    {
        [ValidateNever]
        public int? uid {  get; set; }

        [Display(Name = "Full Name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "*Please enter the username.")]
        [MaxLength(18,ErrorMessage = "*Maximum length is 18 characters.")]
        public string? name { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "*Please enter the password.")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
        ErrorMessage = "*Password must be at least 8 characters long and include an uppercase letter, a lowercase letter, a number, and a special character.")]
        public string? password { get; set; }
      
        [Required(ErrorMessage = "*Please confirm your password.")]
        [Compare("password",ErrorMessage = "*Passwords do not match.")]
        [DataType(DataType.Password)]
        public string? Confirmpassword { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "*Please enter your email.")]
        [EmailAddress(ErrorMessage = "*Invalid email address.")]
        [DataType(DataType.EmailAddress)]
        public string? email { get; set; }
       
        [DataType(DataType.MultilineText)]
        public string? address { get; set; }
     
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "*Please enter your phone number.")]
        [Phone(ErrorMessage = "*Invalid phone number.")]
        public string? phoneNumber { get; set; }
    }
}
