using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class SearchViewItemsSummaryUI : Form
    {
        public SearchViewItemsSummaryUI()
        {
            InitializeComponent();
        }

        ItemStockReportManager aItemReportManager=new ItemStockReportManager();
        List<ItemSockReport> itemReports=new List<ItemSockReport>();

        public void GetCompanyList()
        {
            Company defaultCompany = new Company();
            defaultCompany.CompanyId = -1;
            defaultCompany.CompanyName = "--Select--";
            CompanyManager aCompanyManager=new CompanyManager();
            List<Company> companies = aCompanyManager.GetAllCompany();
            companies.Insert(0,defaultCompany);
            companyComboBox.DataSource = companies;
            companyComboBox.DisplayMember = "CompanyName";
            companyComboBox.ValueMember = "CompanyId";
        }


        public void GetCategoryList()
        {
            CategoryManager aCategoryManager=new CategoryManager();
            Category defaultCategory = new Category();

            defaultCategory.categoryId = -1;
            defaultCategory.CategoryName = "--Select--";

            List<Category> categories = aCategoryManager.GetAllCategory();
            categories.Insert(0,defaultCategory);
            categoryComboBox.DataSource = categories;
            categoryComboBox.DisplayMember = "CategoryName";
            categoryComboBox.ValueMember = "CategoryId";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchViewItemsSummarylistView.Items.Clear();
            ItemSockReport itemReport = new ItemSockReport();

            itemReport.CategoryId = (int) categoryComboBox.SelectedValue;
            itemReport.CompanyId = (int) companyComboBox.SelectedValue;  
          
             itemReports = aItemReportManager.GetItemReport(itemReport);

            foreach (ItemSockReport aItemReport in itemReports)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ((searchViewItemsSummarylistView.Items.Count + 1).ToString());
                item.SubItems.Add(aItemReport.ItemName);
                item.SubItems.Add(aItemReport.CompanyName);
                item.SubItems.Add(aItemReport.CategoryName);
                item.SubItems.Add(aItemReport.AvailableQuantity.ToString());
                item.SubItems.Add(aItemReport.ReorderLevel.ToString());
                item.Tag = aItemReport;
                searchViewItemsSummarylistView.Items.Add(item);
            }

        }



        private void SearchViewItemsSummaryUI_Load(object sender, EventArgs e)
        {
            GetCompanyList();
            GetCategoryList();
        }
    }
}
