using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StockManagementSystem.Gateway;
using StockManagementSystem.Model;

namespace StockManagementSystem.Manager
{
    class ItemManager
    {
        ItemGateway aItemGateway=new ItemGateway();

        public string SaveItem(Item item)
        {
            if (item.ItemName=="")
            {
                return "Item Name must be filled out";
            }
            if (aItemGateway.IsItemExist(item.ItemName))
            {
                return "Item Name Already exist";
            }
            int rowAffected = aItemGateway.SaveItem(item);
            if (rowAffected>0)
            {
                return "Save Successfully";
            }
            return "Failed to Save Item";
        }

        public List<Item> SelectAllItem(int companyId)
        {
            return aItemGateway.SelectAllItem(companyId);
        }


        public Item GetReorderLevel(Item aItem)
        {
            return aItemGateway.GetReorderLevel(aItem);
        }



        public string StockIn(Item aItem)
        {
            int rowAffected = aItemGateway.StockIn(aItem);
            if (rowAffected>0)
            {
                return "Stock In";
            }
            return "Failed Stock In";
        }
    }
}
