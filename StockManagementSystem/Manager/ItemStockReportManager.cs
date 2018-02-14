using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Gateway;
using StockManagementSystem.Model;

namespace StockManagementSystem.Manager
{
    class ItemStockReportManager
    {
        ItemStockReportGateway aItemStockReportGateway=new ItemStockReportGateway();
        public List<ItemSockReport> GetItemReport(ItemSockReport itemReport)
        {
            if (itemReport.CategoryId == -1)
            {
                return aItemStockReportGateway.StockOutReportByCompany(itemReport);
            }
            if (itemReport.CompanyId==-1)
            {
                return aItemStockReportGateway.StockOutReportByCategory(itemReport); 
            }

            
            return aItemStockReportGateway.StockOutReport(itemReport);
        }

       
    }
}
