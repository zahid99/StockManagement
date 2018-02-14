using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Model
{
    class StockOut:Item
    {
        public string CompanyName { set; get; }
        //public string CategoryName { set; get; } 
        public int Quantity { set; get; }
        public DateTime Date { set; get; }
        public string Status { set; get; }

        
    }
}
