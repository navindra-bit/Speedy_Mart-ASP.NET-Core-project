using Microsoft.Data.SqlClient;
using Speedy_Groceries.Models;

namespace Speedy_Groceries.Helpers
{
    public class SqlSignupHelper
    {
        public static bool   UserNameExists(UserInfo userdata)
        {

            string? name = userdata.name;


            using (SqlConnection sqlConnection = new SqlConnection("Data Source=NAVINDRA-M\\SQLEXPRESS; Initial Catalog = SpeedyMartDB; Integrated security=true; encrypt = false"))
            {
                sqlConnection.Open();
                string sql1 = "Select 1 from UserInfo where FullName=@name";
                SqlCommand command = new SqlCommand(sql1, sqlConnection);
                command.Parameters.AddWithValue("@name", userdata.name);
                var value = command.ExecuteScalar();
                if (value != null)
                {
                    return false;
                }
            }
            return true;

        }
        public static  bool  UserEmailExists(UserInfo userdata)
        {
            string? email = userdata.email;
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=NAVINDRA-M\\SQLEXPRESS; Initial Catalog = SpeedyMartDB; Integrated security=true; encrypt = false"))
            {
                sqlConnection.Open();
                string sql2 = "Select 1 from UserInfo where Email=@email";
                SqlCommand command = new SqlCommand(sql2, sqlConnection);

                command.Parameters.AddWithValue("@email", userdata.email);

                var value = command.ExecuteScalar();
                if (value != null)
                {
                    return  false ;
                }
            }
            return  true ;
        }

        public static  bool  UserPhoneNumberExists(UserInfo userdata)
        {
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=NAVINDRA-M\\SQLEXPRESS; Initial Catalog = SpeedyMartDB; Integrated security=true; encrypt = false"))
            {
                sqlConnection.Open();
                string sql3 = "Select 1 from UserInfo where PhoneNumber=@phoneNumber";
                SqlCommand command = new SqlCommand(sql3, sqlConnection);

                command.Parameters.AddWithValue("@phoneNumber", userdata.phoneNumber);

                var value = command.ExecuteScalar();
                if (value != null)
                {
                    return  false ;
                }
            }
            return  true ;
        }

        public static (bool isvaild , string message) UserReg(UserInfo userdata)
        {
            
            string? name = userdata.name;
            string? email = userdata.email;




            string? password = userdata.password!;
            string? password = PasswordHelper.HashPassword(userdata.password!);
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=NAVINDRA-M\\SQLEXPRESS; Initial Catalog = SpeedyMartDB; Integrated security=true; encrypt = false"))
            {
                sqlConnection.Open();
                string sql = "insert into UserInfo (FullName,Email,Password,PhoneNumber) values(@name,@email,@password ,@phoneNumber)";
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                command.Parameters.AddWithValue("@name", userdata.name);
                command.Parameters.AddWithValue("@email", userdata.email);
                command.Parameters.AddWithValue("@password", password);                
                command.Parameters.AddWithValue("@phoneNumber", userdata.phoneNumber);
                int value = command.ExecuteNonQuery();
                if (value > 0)
                {
                    return (true, "Registration successful");
                }
            }
            return (false, "Registration failed !");
        }

    }
}
