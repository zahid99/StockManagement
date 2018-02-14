using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Model;

namespace StockManagementSystem.Gateway
{
    class CategoryGateway
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["ShopConnectionString"].ConnectionString;
        private string query;
        private SqlCommand command;
        private SqlDataReader reader;

        public int SaveCategory(Category aCategory)
        {
            SqlConnection connection=new SqlConnection(connectionString);
            connection.Open();
            query = "INSERT INTO Category (CategoryName)  VALUES (@CategoryName)";
             command=new SqlCommand(query,connection);
            command.Parameters.Clear();
            command.Parameters.Add("CategoryName", SqlDbType.NVarChar);
            command.Parameters["CategoryName"].Value = aCategory.CategoryName;
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected; ;

        }

        public List<Category> GetAllCategory()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
             query = "SELECT * FROM Category";
             command = new SqlCommand(query, connection);
             reader = command.ExecuteReader();
            List<Category> categories=new List<Category>();

            while (reader.Read())
            {
                Category aCategory=new Category();
                aCategory.categoryId =Convert.ToInt32( reader["CategoryId"]);
                aCategory.CategoryName = reader["CategoryName"].ToString();
                categories.Add(aCategory);
            }
            reader.Close();
            connection.Close();
            return categories;
        }

        public bool IsCategoryExist(string categoryName)
        {
            SqlConnection connection=new SqlConnection(connectionString);
            query = "SELECT *FROM Category WHERE CategoryName=@CategoryName ";
            command=new SqlCommand(query,connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("CategoryName", categoryName);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExist;

        }


        public int UpdateCategory(Category category)
        {
            SqlConnection connection=new SqlConnection(connectionString);
            query = "UPDATE Category SET Categoryname=@CategoryName WHERE categoryId=@CategoryId";
            connection.Open();
            command=new SqlCommand(query,connection);

            command.Parameters.Clear();
            command.Parameters.AddWithValue("CategoryName", category.CategoryName);
            command.Parameters.AddWithValue("CategoryId", category.categoryId);

          int rowAffected=  command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

    }
}
