using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Model
{
   public class Item
    {
        public int ItemId { set; get; }
        public string ItemName { set; get; }
        public int CategoryId { set; get; }
        public int CompanyId { set; get; }
        public int ReorderLevel { set; get; }
        public int AvailableQuantity { set; get; }

        public int StockIn(int quantity)
        {
            AvailableQuantity += quantity;
            return AvailableQuantity;
        }

        public  bool StockOut(int quantity)
        {
            if (AvailableQuantity-quantity>=ReorderLevel)
            {
                AvailableQuantity -= quantity;
                return true;
            }
            return false;
        }
    }
}
