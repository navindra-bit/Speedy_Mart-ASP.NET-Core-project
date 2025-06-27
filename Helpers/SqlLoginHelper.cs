using Microsoft.Data.SqlClient;
using Speedy_Groceries.Models;
 
namespace Speedy_Groceries.Helpers
{
    public class SqlLoginHelper
    {

        public static bool Logcheck(UserInfo info)
        {
            string password = PasswordHelper.HashPassword(info.password);
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=NAVINDRA-M\\SQLEXPRESS; Initial Catalog = EwebUserInfo; Integrated security=true; encrypt = false"))
            {
                sqlConnection.Open();
                string sql = "select 1 from userdata where email= @email and password= @password";
                SqlCommand command = new SqlCommand(sql, sqlConnection);

                command.Parameters.AddWithValue("@email", info.email);
                command.Parameters.AddWithValue("@password", password);

                 var IsVaildLog = command.ExecuteScalar();
                return IsVaildLog!=null;
            }
             
        }
    }
}
