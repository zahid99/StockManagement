using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StockManagementSystem.Gateway;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class ItemUI : Form
    {
        public ItemUI()
        {
            InitializeComponent();
 
        }

         CategoryManager aCategoryManager=new CategoryManager();
         CompanyManager  aCompanyManager=new CompanyManager();
         ItemManager aItemManager=new ItemManager();
 

        public void GetCategoryList()
        {
            List<Category> categories = aCategoryManager.GetAllCategory();
            categoryNameComboBox.DataSource = categories;
            categoryNameComboBox.DisplayMember = "CategoryName";
            categoryNameComboBox.ValueMember = "CategoryId";
        }

        public void GetCompanyList()
        {
            List<Company> companies = aCompanyManager.GetAllCompany();
            companyNameComboBox.DataSource = companies;
            companyNameComboBox.DisplayMember = "CompanyName";
            companyNameComboBox.ValueMember = "CompanyId";
        }

        private void ItemUI_Load(object sender, EventArgs e)
        {
            GetCategoryList();
            GetCompanyList();
            reorderLevelTextBox.Text = 0.ToString();
        }

        private void itemSaveButton_Click(object sender, EventArgs e)
        {
            Item aItem=new Item();
            
   
            try
            {
                aItem.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
            }
            catch (Exception )
            {
                MessageBox.Show("Please input Reorder Level numeric characters only");
                return;
            }
            
            aItem.CategoryId = (int) categoryNameComboBox.SelectedValue;
            aItem.CompanyId = (int) companyNameComboBox.SelectedValue;
            aItem.ItemName = itemNameTextBox.Text;
            aItem.AvailableQuantity = 0;
            string message = aItemManager.SaveItem(aItem);
            MessageBox.Show(message);

            itemNameTextBox.Text = "";
            reorderLevelTextBox.Text = "";
        }
    }
}
