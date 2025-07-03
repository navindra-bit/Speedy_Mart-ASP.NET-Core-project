using Microsoft.Data.SqlClient;
using Speedy_Groceries.Models;
 
namespace Speedy_Groceries.Helpers
{
    public class SqlLoginHelper
    {
        public static bool UserEmailExists(string userdata)
        {
            string? email = userdata ;
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=NAVINDRA-M\\SQLEXPRESS; Initial Catalog = SpeedyMartDB; Integrated security=true; encrypt = false"))
            {
                sqlConnection.Open();
                string sql2 = "Select 1 from UserInfo where Email=@email";
                SqlCommand command = new SqlCommand(sql2, sqlConnection);

                command.Parameters.AddWithValue("@email", userdata );

                var value = command.ExecuteScalar();
                if (value != null)
                {
                    return false;
                }
            }
            return true;
        }
        public static (bool,string?,string?) Logcheck(LoginInfo info)
        {


            string password = info.Loginpassword!;
            // string password = PasswordHelper.HashPassword(info.Loginpassword!); 
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=NAVINDRA-M\\SQLEXPRESS; Initial Catalog = SpeedyMartDB; Integrated security=true; encrypt = false"))
            {
                sqlConnection.Open();
                string sql = "select * from UserInfo where Email= @email and Password= @password";
                SqlCommand command = new SqlCommand(sql, sqlConnection);

                command.Parameters.AddWithValue("@email", info.Loginemail);
                command.Parameters.AddWithValue("@password", password);

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    string?  Id = dataReader["UserId"] != DBNull.Value ? dataReader["UserId"].ToString() : "0";
                    string? name = dataReader["FullName"] != DBNull.Value ? dataReader["FullName"].ToString() : "UserName";
                    return (true, name,  Id);
                }
                return (false, string.Empty,string.Empty);
            }
             
        }
    }
}
