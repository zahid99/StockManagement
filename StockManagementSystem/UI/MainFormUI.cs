using System;
using System.Windows.Forms;

namespace StockManagementSystem.UI
{
    public partial class MainFormUI : Form
    {
        public MainFormUI()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryUi category1=new CategoryUi();
            category1.Show();
        }

        private void addCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyUI company1=new CompanyUI();
            company1.Show();
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemUI item1=new ItemUI();
            item1.Show();
        }

        private void stockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockInUI stock1=new StockInUI();
            stock1.Show();
        }

        private void stockOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockOutUI stock2=new StockOutUI();
            stock2.Show();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        partial void Dispose(bool disposing);

        private void searchViewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchViewItemsSummaryUI searchViewItems=new SearchViewItemsSummaryUI();
            searchViewItems.Show();
        }

        private void viewSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewSalesBetweenTwoDatesUI viewSales=new ViewSalesBetweenTwoDatesUI();
            viewSales.Show();
        }

        private void addCategotyButton_Click(object sender, EventArgs e)
        {
            CategoryUi category1 = new CategoryUi();
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

        private void stockOutButton_Click(object sender, EventArgs e)
        {
            StockOutUI stock2 = new StockOutUI();
            stock2.Show();
        }

        private void searchItemButton_Click(object sender, EventArgs e)
        {
            SearchViewItemsSummaryUI searchViewItems = new SearchViewItemsSummaryUI();
            searchViewItems.Show();
        }

        private void itemReportButton_Click(object sender, EventArgs e)
        {
            ViewSalesBetweenTwoDatesUI viewSales = new ViewSalesBetweenTwoDatesUI();
            viewSales.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
