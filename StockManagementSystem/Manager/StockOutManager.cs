using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Gateway;
using StockManagementSystem.Model;

namespace StockManagementSystem.Manager
{
    class StockOutManager
    {
        StockOutgateway aStockOutgateway=new StockOutgateway();

        public string SaveStockReport(List<StockOut> itemReports,string stockOutStatus)
        {
            int rowAffected = aStockOutgateway.SaveStockOutReport(itemReports,stockOutStatus);
            if (rowAffected>0)
            {
                return "Save";
            }
            return "Failed";
        }


        public string StockOut(List<StockOut> itemReports)
        {
            int rowAffected = aStockOutgateway.StockOut(itemReports);
            if (rowAffected > 0)
            {
                return "Save";
            }
            return "Failed";
        }



        public List<StockOut> SalesStockOutsReport(string fromdate, string toDate)
        {
            return aStockOutgateway.SalesStockOutsReport(fromdate, toDate);
        }

        
    }
}
