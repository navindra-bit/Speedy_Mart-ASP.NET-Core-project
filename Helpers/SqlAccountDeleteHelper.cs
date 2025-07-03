using Microsoft.Data.SqlClient;
using Speedy_Groceries.Models;

namespace Speedy_Groceries.Helpers
{
    public class SqlAccountDeleteHelper
    {
        //public static (bool, string?) AccDelete(UserInfo info)
        //{
        //    string password = PasswordHelper.HashPassword(info.password!);
        //    using (SqlConnection sqlConnection = new SqlConnection("Data Source=NAVINDRA-M\\SQLEXPRESS; Initial Catalog = SpeedyMartDB; Integrated security=true; encrypt = false"))
        //    {
        //        sqlConnection.Open();
        //        string sql = "DELETE FROM UserInfo WHERE Email = @email AND Password = @password";
        //        SqlCommand command = new SqlCommand(sql, sqlConnection);

        //        command.Parameters.AddWithValue("@email", info.email);
        //        command.Parameters.AddWithValue("@password", password);

        //        int value = command.ExecuteNonQuery();
        //        if (value > 0)
        //        {
        //            return (true, "Deleted Account successful");
        //        }
        //        return (false, string.Empty);
        //    }

        //}
        public static (bool, string?) AccDelete(string Userid)
        {
            
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=NAVINDRA-M\\SQLEXPRESS; Initial Catalog = SpeedyMartDB; Integrated security=true; encrypt = false"))
            {
                sqlConnection.Open();
                string sql = "DELETE FROM UserInfo WHERE  UserId=@Userid";
                SqlCommand command = new SqlCommand(sql, sqlConnection);

                command.Parameters.AddWithValue("@Userid", Userid);
                

                int value = command.ExecuteNonQuery();
                if (value > 0)
                {
                    return (true, "Deleted Account successful");
                }
                return (false, string.Empty);
            }

        }
    }
}
