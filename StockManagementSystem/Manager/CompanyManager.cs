using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Gateway;
using StockManagementSystem.Model;

namespace StockManagementSystem.Manager
{
    class CompanyManager
    {

       private  CompanyGateway aCompanyGateway=new CompanyGateway();
        public string SaveCompany(Company aCompany)
        {

            if (aCompany.CompanyName == "")
            {
                return "Company Name must be filled out";
            }
            if (aCompanyGateway.IsCompanyExist(aCompany.CompanyName))
            {
                return "Company Already Exist";
            }

            int row = aCompanyGateway.SaveCompany(aCompany);
            if (row>0)
            {
                return "Save Successfully";
            }
            return "Failed";
        }

        public List<Company> GetAllCompany()
        {
            return aCompanyGateway.GetAllCompany();
        }

        public string UpdateCompany(Company company)
        {

            if (aCompanyGateway.IsCompanyExist(company.CompanyName))
            {
                return "Company name already Exist";
            }

            int rowAffected = aCompanyGateway.UpdateCompany(company);
            if (rowAffected>0)
            {
                return "Update Successfully";
            }
            return "Failed to Update";
        }
    }
}
