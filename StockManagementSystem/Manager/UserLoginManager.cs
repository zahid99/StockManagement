using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Gateway;

namespace StockManagementSystem.Manager
{
    class UserLoginManager
    {
        UserLoginGateway aUserLoginGateway=new UserLoginGateway();

        public bool IsExist(string userName, string password)
        {
            if (aUserLoginGateway.IsExist(userName,password))
            {
                return true;
            }
            return false;
        }
    }
}
