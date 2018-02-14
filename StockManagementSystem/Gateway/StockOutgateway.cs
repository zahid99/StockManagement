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
    class StockOutgateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ShopConnectionString"].ConnectionString;
        private string query;
        private SqlCommand command;
        private SqlDataReader reader;


        public int SaveStockOutReport(List<StockOut> stockOuts,string stockOutStatus)
        {
            int rowAffected=0;
            SqlConnection connection = new SqlConnection(connectionString);
            foreach (StockOut aStockOut in stockOuts)
            {
                query = "INSERT INTO StockReport VALUES(@companyId,@itemId,@quantity,@stockOutStatus,@date)";
                connection.Open();
                command = new SqlCommand(query, connection);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("companyId", aStockOut.CompanyId);
                command.Parameters.AddWithValue("itemId", aStockOut.ItemId);
                command.Parameters.AddWithValue("quantity", aStockOut.Quantity);
                command.Parameters.AddWithValue("stockOutStatus", stockOutStatus);
                command.Parameters.AddWithValue("date", aStockOut.Date);

                rowAffected += command.ExecuteNonQuery();
                connection.Close();
            } 
            return rowAffected;
        }



        
        public int StockOut(List<StockOut> stockOuts)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(connectionString);

            foreach (StockOut aStockOut in stockOuts)
            {
                query = "UPDATE  Item SET AvailableQuantity=@availableQuantity WHERE ItemId=@itemid AND CompanyId=@companyId";
                connection.Open();
                command = new SqlCommand(query, connection);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("availableQuantity", aStockOut.AvailableQuantity);
                command.Parameters.AddWithValue("itemid", aStockOut.ItemId);
                command.Parameters.AddWithValue("companyId", aStockOut.CompanyId);
                rowAffected += command.ExecuteNonQuery();
                connection.Close();
            }
            return rowAffected;
        }



        public List<StockOut> SalesStockOutsReport(string startDate,string endDate)
        {
            SqlConnection connection = new SqlConnection(connectionString);
           // query = "SELECT Item.ItemName,StockReport.ItemId,SUM(Quantity) AS TOTAL FROM StockReport ,Item WHERE StockReport.Date BETWEEN '"+startDate+"' AND '"+endDate+"' AND status='Sold' AND Item.ItemId=StockReport.ItemId GROUP BY StockReport.ItemId,Item.itemName ";
            query = "select itemName ,sum(Quantity) as total from StockreportView where date between @startDate AND @endDate group by ItemName";
            connection.Open();
            command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("startDate", startDate);
            command.Parameters.AddWithValue("endDate", endDate);
            reader = command.ExecuteReader();
            List<StockOut> items = new List<StockOut>();

            while (reader.Read())
            {
                StockOut aItem = new StockOut();
                aItem.ItemName = reader["ItemName"].ToString();

                aItem.Quantity = Convert.ToInt32(reader["total"]);
                items.Add(aItem);

            }
            reader.Close();
            connection.Close();
            return items;
        }




    }
}
