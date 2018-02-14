using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Model;

namespace StockManagementSystem.Gateway
{
    class CompanyGateway
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["ShopConnectionString"].ConnectionString;
        private string query;
        private SqlCommand command;
        private SqlDataReader reader;

       
         
        public int SaveCompany(Company aCompany)
        {
             SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand("INSERT INTO Company VALUES(@CompanyName)", connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("CompanyName", aCompany.CompanyName);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }

        public List<Company> GetAllCompany()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Company", connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Company> company=new List<Company>();

            while (reader.Read())
            {
                Company aCompany=new Company();
                aCompany.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                aCompany.CompanyName = reader["CompanyName"].ToString();
                company.Add(aCompany);

            }
            reader.Close();
            connection.Close();
            return company;

        }


        public bool IsCompanyExist(string companyName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            query = "SELECT *FROM Company WHERE CompanyName=@companyName";
            command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("companyName", companyName);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExist;

        }

        public int UpdateCompany(Company company)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            query = "UPDATE Company SET CompanyName=@CompanyName WHERE CompanyId=@CompanyId";
            connection.Open();
            command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("CompanyName", company.CompanyName);
            command.Parameters.AddWithValue("CompanyId", company.CompanyId);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }


    }
}
