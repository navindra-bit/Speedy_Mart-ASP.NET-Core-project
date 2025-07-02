using System.ComponentModel.DataAnnotations;

namespace Speedy_Groceries.Models
{
    public class UserInfo
    {
        public int? uid {  get; set; }
        [DataType(DataType.Text)]
        public string? name { get; set; }
        [DataType(DataType.Password)]
        public string? password { get; set; }
        [DataType(DataType.Password)]
        public string? Confirmpassword { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? email { get; set; }
        [DataType(DataType.MultilineText)]
        public string? address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public long? phoneNumber { get; set; }
    }
}
