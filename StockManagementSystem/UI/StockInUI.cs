using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class StockInUI : Form
    {
        public StockInUI()
        {
            InitializeComponent();
            
        }
        ItemManager aItemManager = new ItemManager();

        public void GetCompanyList()
        {
            Company defaultCompany=new Company();
            defaultCompany.CompanyId = -1;
            defaultCompany.CompanyName = "--Select--";

            CompanyManager aCompanyManager=new CompanyManager();
            List<Company> companies = aCompanyManager.GetAllCompany();
            companies.Insert(0,defaultCompany);
            companyNameComboBox.DataSource = companies;
            companyNameComboBox.DisplayMember = "CompanyName";
            companyNameComboBox.ValueMember = "CompanyId";
        }

        public void GetItemReorderLevel()
        {           
            Item aItem=new Item();
            aItem.ItemName = itemNameComboBox.Text;
            aItem= aItemManager.GetReorderLevel(aItem);
            reorderLevelTextBox.Text = aItem.ReorderLevel.ToString();
            availableQuantityTextBox.Text = aItem.AvailableQuantity.ToString();

        }


        public void GetItemList()
        {
            Item defaultItem = new Item();
            defaultItem.ItemId = -1;
            defaultItem.ItemName = "--Select--";
            if (companyNameComboBox.SelectedValue is int)
            {
                int companyId = Convert.ToInt32(companyNameComboBox.SelectedValue);

                List<Item> items = aItemManager.SelectAllItem(companyId);
                items.Insert(0, defaultItem);
                itemNameComboBox.DataSource = items;
                itemNameComboBox.DisplayMember = "ItemName";
                itemNameComboBox.ValueMember = "ItemId"; 
            }
                
               
        }


        private void stockSaveButton_Click(object sender, EventArgs e)
        {
            int quantity;
            Item aItem=new Item();
            aItem.ItemName = itemNameComboBox.Text;
            aItem.CompanyId = (int) companyNameComboBox.SelectedValue;

            
            try
            {
                aItem.AvailableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
                 quantity = Convert.ToInt32(stockInQuantityTextBox.Text);
            }
            catch (Exception )
            {
                MessageBox.Show("Input Field must numeric ");
                stockInQuantityTextBox.Text = "";
                return;
            }
            aItem.StockIn(quantity);  
            ItemManager aItemManager = new ItemManager();
            string message= aItemManager.StockIn(aItem);
            MessageBox.Show(message);
            reorderLevelTextBox.Text = "";
            availableQuantityTextBox.Text = "";
            stockInQuantityTextBox.Text = "";

        }

        private void StockInUI_Load(object sender, EventArgs e)
        {
            GetCompanyList();
        }

        private void companyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItemList();
            reorderLevelTextBox.Text = "";
            availableQuantityTextBox.Text = "";


        }

        

        private void itemNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItemReorderLevel();
        }

       
    }
}
