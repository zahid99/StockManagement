using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class StockOutUI : Form
    {
        public StockOutUI()
        {
            InitializeComponent();
        }

        CompanyManager aCompanyManager = new CompanyManager();
        StockOutManager aStockOutManager=new StockOutManager();
        public void GetCompanyList()
        {
            Company defaultCompany = new Company();
            defaultCompany.CompanyId = -1;
            defaultCompany.CompanyName = "--Select--";
           
            List<Company> companies = aCompanyManager.GetAllCompany();
            companies.Insert(0,defaultCompany);
            companyNameComboBox.DataSource = companies;
            companyNameComboBox.DisplayMember = "CompanyName";
            companyNameComboBox.ValueMember = "CompanyId";
        }


        public void GetItemList()
        {
            itemComboBox.Text = "";
            ItemManager aItemManager = new ItemManager();
            Item defaultItem = new Item();
            defaultItem.ItemId = -1;
            defaultItem.ItemName = "--Select--";

            if (companyNameComboBox.SelectedValue is int)
            {
                int companyId = Convert.ToInt32(companyNameComboBox.SelectedValue);
                List<Item> items = aItemManager.SelectAllItem(companyId);
                items.Insert(0,defaultItem);
                itemComboBox.DataSource = items;
                itemComboBox.DisplayMember = "ItemName";
                itemComboBox.ValueMember = "ItemId"; 
            }
           
        }



        public void GetItemReorderLevel()
        {
            ItemManager aItemManager = new ItemManager();
            Item aItem = new Item();
            aItem.ItemName = itemComboBox.Text;
            aItem = aItemManager.GetReorderLevel(aItem);
            reorderLevelTextBox.Text = aItem.ReorderLevel.ToString();
            availableQuentityTextBox.Text = aItem.AvailableQuantity.ToString();

        }

        List<StockOut> stockOuts = new List<StockOut>();
        
        private void addButton_Click(object sender, EventArgs e)
        {
            StockOut aStockOut = new StockOut();
            aStockOut.ItemName = itemComboBox.Text;

            try
            {
                aStockOut.Quantity = Convert.ToInt32(quantityTextBox.Text);
            }
            catch (Exception )
            {
                MessageBox.Show("Please input Reorder Level numeric characters only");
                quantityTextBox.Text = "";
                return;
            }
            aStockOut.AvailableQuantity = Convert.ToInt32(availableQuentityTextBox.Text);
            
            aStockOut.Date = DateTime.Today;
            aStockOut.CategoryId = (int) itemComboBox.SelectedValue;
            aStockOut.CompanyId = (int) companyNameComboBox.SelectedValue;
            aStockOut.CompanyName = companyNameComboBox.Text;
            aStockOut.ItemId = (int) itemComboBox.SelectedValue;
            aStockOut.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);

            bool check = aStockOut.StockOut(aStockOut.Quantity);
            if (check==true)
            {
                stockOuts.Add(aStockOut); 
            }
            else
            {
                MessageBox.Show("Stock Not Available");
            }
 
            StockOutListView();
            Clear();
        }

        void StockOutListView()
        {
           
            stockOutListView.Items.Clear();
            foreach (StockOut itemReport in stockOuts)
            {
                ListViewItem listViewItem=new ListViewItem();
                listViewItem.Text = ((stockOutListView.Items.Count + 1).ToString());
                listViewItem.SubItems.Add(itemReport.ItemName.ToString());
                listViewItem.SubItems.Add(itemReport.CompanyName.ToString());
                listViewItem.SubItems.Add(itemReport.Quantity.ToString());
               
                stockOutListView.Items.Add(listViewItem);
            }
        }

        private void StockOutUI_Load(object sender, EventArgs e)
        {
            GetCompanyList();
        }

       

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItemReorderLevel();
        }

        private void sellButton_Click(object sender, EventArgs e)
        {
            StockOut aStockOut = new StockOut();
            aStockOut.Status = "Sold";
            MessageBox.Show(aStockOut.ItemName+aStockOut.Status);
             aStockOutManager.SaveStockReport(stockOuts,aStockOut.Status);

            string msg = aStockOutManager.StockOut(stockOuts);
            MessageBox.Show(msg);           
            //MessageBox.Show(message);
            stockOutListView.Items.Clear();
            stockOuts.Clear();

        }

        
        private void damageButton_Click(object sender, EventArgs e)
        {
            StockOut aStockOut = new StockOut();
            //ItemReport aStockOut = new ItemReport();
             aStockOut.Status = "Damage";
            MessageBox.Show(aStockOut.ItemName + aStockOut.Status);
            aStockOutManager.SaveStockReport(stockOuts, "Damage");
            string msg = aStockOutManager.StockOut(stockOuts);
            MessageBox.Show(msg);
            //MessageBox.Show(message);
            //MessageBox.Show(message);
            stockOutListView.Items.Clear();
            stockOuts.Clear();
        }

        private void lostButton_Click(object sender, EventArgs e)
        {
            StockOut aStockOut = new StockOut();
            MessageBox.Show(aStockOut.ItemName + aStockOut.Status);
            string message = aStockOutManager.SaveStockReport(stockOuts,"Lost");
            string msg=aStockOutManager.StockOut(stockOuts);
            MessageBox.Show(msg);
            //MessageBox.Show(message);
            stockOutListView.Items.Clear();
            stockOuts.Clear();
        }


        void Clear()
        {
            reorderLevelTextBox.Text = "";
            availableQuentityTextBox.Text = "";
            quantityTextBox.Text = "";
        }

        private void companyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItemList();
            Clear();
        }
    }
}
