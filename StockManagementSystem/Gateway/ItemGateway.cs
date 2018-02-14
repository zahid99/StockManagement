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
    class ItemGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ShopConnectionString"].ConnectionString;
        private string query;
        private SqlCommand command;
        private SqlDataReader reader;

        public int SaveItem(Item aItem)
        {
            SqlConnection connection=new SqlConnection(connectionString);
            query = "INSERT INTO Item VALUES(@ItemName,@CategoryId,@CompanyId,@ReorderLevel,@AvailableQuantity)";
            connection.Open();

            command=new SqlCommand(query,connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("ItemName", aItem.ItemName);
            command.Parameters.AddWithValue("CategoryId", aItem.CategoryId);
            command.Parameters.AddWithValue("CompanyId", aItem.CompanyId);
            command.Parameters.AddWithValue("ReorderLevel", aItem.ReorderLevel);
            command.Parameters.AddWithValue("AvailableQuantity", aItem.AvailableQuantity);
            
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }

        public List<Item> SelectAllItem(int companyId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            query = "SELECT * FROM Item WHERE CompanyId=@companyId";
            connection.Open();
            command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("companyId", companyId);
            reader = command.ExecuteReader();
            List<Item> items = new List<Item>();

            while (reader.Read())
            {
                Item item = new Item();
                item.ItemId = Convert.ToInt32(reader["ItemId"]);
                item.ItemName = reader["ItemName"].ToString();
                items.Add(item);

            }
            reader.Close();
            connection.Close();
            return items;
          
        }

        public Item GetReorderLevel(Item aItem)
        {
           
            SqlConnection connection = new SqlConnection(connectionString);
            query = "SELECT * FROM Item WHERE ItemName=@itemName";
            connection.Open();
            command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("itemName", aItem.ItemName);
            reader = command.ExecuteReader();
            Item item=new Item();
            while (reader.Read())
            {

                item.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                item.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
            }
            reader.Close();
            connection.Close();
            return item;
            
        }


        public int StockIn(Item  aItem)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            query = "UPDATE  Item SET AvailableQuantity=@availableQuantity WHERE ItemName=@itemName AND CompanyId=@companyid";
            connection.Open();
            command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("availableQuantity", aItem.AvailableQuantity);
            command.Parameters.AddWithValue("itemName", aItem.ItemName);
            command.Parameters.AddWithValue("companyid", aItem.CompanyId);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }





        public bool IsItemExist(string itemName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            query = "SELECT *FROM Item WHERE ItemName=@itemName";
            command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("itemname", itemName);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExist;

        }
    }
}
