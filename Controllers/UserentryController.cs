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
       
        public IActionResult Userdata(UserInfo userdata)
        {
             string name =userdata.name;
             string email = userdata.email;
            string password = userdata.password;

            SqlConnection sqlConnection = new SqlConnection("Data Source=NAVINDRA-M\\SQLEXPRESS; Initial Catalog = EwebUserInfo; Integrated security=true; encrypt = false");
            sqlConnection.Open();
            string sql = "insert into userdata (name,email,password,address,phoneNumber) values(@name,@email,@password,@address,@phoneNumber)";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            command.Parameters.AddWithValue("@name",userdata.name);
            command.Parameters.AddWithValue("@email", userdata.email);
            command.Parameters.AddWithValue("@password", userdata.password);
            command.Parameters.AddWithValue("@address",string.IsNullOrEmpty( userdata.address) ? DBNull.Value : userdata.address);
            command.Parameters.AddWithValue("@phoneNumber", userdata.phoneNumber.HasValue ? userdata.phoneNumber.Value : DBNull.Value);
            int value = command.ExecuteNonQuery();
            sqlConnection.Close();
            if (value > 0)
            {
                return View("Login");
            }
             
            
            return NoContent();
        }
        public  IActionResult UserLog(UserInfo userdata)
        {

            using (SqlConnection sqlConnection = new SqlConnection("Data Source=NAVINDRA-M\\SQLEXPRESS; Initial Catalog = EwebUserInfo; Integrated security=true; encrypt = false"))
            {
                sqlConnection.Open();
                string sql = "select email, password from userdata where email= @email and password= @password";
                SqlCommand command = new SqlCommand(sql, sqlConnection);

                command.Parameters.AddWithValue("@email", userdata.email);
                command.Parameters.AddWithValue("@password", userdata.password);

                SqlDataReader reader = command.ExecuteReader();
                 
                if (reader.HasRows)
                {
                    reader.Close();
                    return RedirectToAction("Index", "Home");
                }
                reader.Close();
            }
            ViewBag.Message = "Invalid email or password";
            return View("Login");
        }
    }
}
