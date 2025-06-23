using Microsoft.AspNetCore.Mvc;
using Speedy_Groceries.Models;
using Microsoft.Data.SqlClient;
namespace Speedy_Groceries.Controllers
{
    public class UserentryController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
             
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            UserInfo user = new UserInfo();
            return View(user);
        }
        [HttpPut]
        public IActionResult Userdata(UserInfo userdata)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=NAVINDRA-M\\SQLEXPRESS; Initial Catalog = EwebUserInfo; Integrated security=true; encrypt = false");
            sqlConnection.Open();
            string sql = "insert into userdata (name,email,password,address,phoneNumber) values(@name,@email,@password,@address,@phoneNumber)";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            command.Parameters.AddWithValue("@name",userdata.name);
            command.Parameters.AddWithValue("@email", userdata.email);
            command.Parameters.AddWithValue("@password", userdata.password);
            command.Parameters.AddWithValue("@address", userdata.address);
            command.Parameters.AddWithValue("@phoneNumber", userdata.phoneNumber);
            int value = command.ExecuteNonQuery();
            sqlConnection.Close();
            if (value > 0)
            {
                return View("Login");
            }
            return NoContent();
        }
    }
}
