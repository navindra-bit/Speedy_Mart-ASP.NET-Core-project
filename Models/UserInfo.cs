namespace Speedy_Groceries.Models
{
    public class UserInfo
    {
        public int? uid {  get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string? address { get; set; }
        public int? phoneNumber { get; set; }
    }
}
