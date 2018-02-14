using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Gateway
{
    class UserLoginGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ShopConnectionString"].ConnectionString;
        private string query;
        private SqlCommand command;
        private SqlDataReader reader;


        public bool IsExist(string userName,string password)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            query = "SELECT *FROM Login WHERE UserName=@username AND Password=@password";
            command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("username", userName);
            command.Parameters.AddWithValue("password", password);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExist;

        }
    }
}
