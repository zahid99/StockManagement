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
    class ItemStockReportGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ShopConnectionString"].ConnectionString;
        private string query;
        private SqlCommand command;
        private SqlDataReader reader;

        public List<ItemSockReport> StockOutReport(ItemSockReport item)
        {
            SqlConnection connection = new SqlConnection(connectionString);
          
            query = "SELECT *FROM [ItemWithCategory] WHERE CompanyId=@CompanyId AND CategoryId=@CategoryId ";
            connection.Open();
            command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("CompanyId", item.CompanyId);
            command.Parameters.AddWithValue("CategoryId", item.CategoryId);
            reader = command.ExecuteReader();
            List<ItemSockReport> items = new List<ItemSockReport>();

            while (reader.Read())
            {
                ItemSockReport aItem = new ItemSockReport();
                aItem.ItemName = reader["ItemName"].ToString();
                aItem.CompanyName = reader["Companyname"].ToString();
                aItem.CategoryName = reader["CategoryName"].ToString();
                aItem.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                aItem.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                items.Add(aItem);

            }
            reader.Close();
            connection.Close();
            return items;
        }

        public List<ItemSockReport> StockOutReportByCompany(ItemSockReport item)
        {
            SqlConnection connection = new SqlConnection(connectionString);            
            query = "SELECT *FROM [ItemWithCategory] WHERE CompanyId=@CompanyId ";
            connection.Open();
            command = new SqlCommand(query, connection);

            command.Parameters.Clear();
            command.Parameters.AddWithValue("CompanyId", item.CompanyId);           
            reader = command.ExecuteReader();
            List<ItemSockReport> items = new List<ItemSockReport>();

            while (reader.Read())
            {
                ItemSockReport aItem = new ItemSockReport();
                aItem.ItemName = reader["ItemName"].ToString();
                aItem.CompanyName = reader["Companyname"].ToString();
                aItem.CategoryName = reader["CategoryName"].ToString();
                aItem.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                aItem.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                items.Add(aItem);

            }
            reader.Close();
            connection.Close();
            return items;
        }

        public List<ItemSockReport> StockOutReportByCategory(ItemSockReport item)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            query = "SELECT *FROM [ItemWithCategory] WHERE CategoryId=@CategoryId ";
            connection.Open();
            command = new SqlCommand(query, connection);

            command.Parameters.Clear();
            command.Parameters.AddWithValue("CategoryId", item.CategoryId);
            reader = command.ExecuteReader();
            List<ItemSockReport> items = new List<ItemSockReport>();

            while (reader.Read())
            {
                ItemSockReport aItem = new ItemSockReport();
                aItem.ItemName = reader["ItemName"].ToString();
                aItem.CompanyName = reader["Companyname"].ToString();
                aItem.CategoryName = reader["CategoryName"].ToString();
                aItem.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                aItem.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                items.Add(aItem);

            }
            reader.Close();
            connection.Close();
            return items;
        }

    }
}
