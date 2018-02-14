using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem.UI
{
    public partial class MainForm2 : Form
    {
        public MainForm2()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            CategoryUi category1 = new CategoryUi();            
            category1.MdiParent = this;
            category1.Hide();
            category1.Show();
            
        }

        private void addCompanyButton_Click(object sender, EventArgs e)
        {
            CompanyUI company1 = new CompanyUI();
            company1.Show();
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            ItemUI item1 = new ItemUI();
            item1.Show();
        }

        private void stockInButton_Click(object sender, EventArgs e)
        {
            StockInUI stock1 = new StockInUI();
            stock1.Show();
        }

        private void stockoutButton_Click(object sender, EventArgs e)
        {
            StockOutUI stock2 = new StockOutUI();
           
            stock2.Show();
        }

        private void searchItemButton_Click(object sender, EventArgs e)
        {
            SearchViewItemsSummaryUI searchViewItems = new SearchViewItemsSummaryUI();
            searchViewItems.MdiParent = this;
            searchViewItems.Show();
        }

        private void searchSalesButton_Click(object sender, EventArgs e)
        {
            ViewSalesBetweenTwoDatesUI viewSales = new ViewSalesBetweenTwoDatesUI();
            viewSales.Show();
        }
    }
}
