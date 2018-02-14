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
    class CategoryManager
    {

        CategoryGateway aCategoryGateway=new CategoryGateway();

        public string SaveCategory(Category aCategory)
        {
            if (aCategory.CategoryName=="")
            {
                return "Category Name must be filled out";
            }
            if (aCategoryGateway.IsCategoryExist(aCategory.CategoryName))
            {
                return "Category Name already Exist";
            }
          int rowAffected=aCategoryGateway.SaveCategory(aCategory);
            if (rowAffected>0)
            {
                return "Save";
            }
            return "Failed";
        }


        public List<Category> GetAllCategory()
        {
            return aCategoryGateway.GetAllCategory();
        }

        public string UpdateCategory(Category aCategory)
        {

            if (aCategoryGateway.IsCategoryExist(aCategory.CategoryName))
            {
                return "Category Already Exist";
            }
            int rowAffected= aCategoryGateway.UpdateCategory(aCategory);
            if (rowAffected > 0)
            {
                return "Update Succesfully";
            }
            return "Failed ";
        }
    }
}
