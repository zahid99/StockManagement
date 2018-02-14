using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class ViewSalesBetweenTwoDatesUI : Form
    {
        public ViewSalesBetweenTwoDatesUI()
        {
            InitializeComponent();
        }

       StockOutManager aStockOutManager=new StockOutManager();
         List<StockOut> itemReports=new List<StockOut>();



        private void searchButton_Click(object sender, EventArgs e)
        {
            viewSalesBetweenTwoDatesListView.Items.Clear();
            DateTime startDateTime = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime endDateTime = Convert.ToDateTime(dateTimePicker2.Text);
            if (endDateTime < startDateTime)
            {
                MessageBox.Show("From Date must be equal or smaller than To Date");
                return;
            }
            string fromDate = dateTimePicker1.Text;
            string toDate = dateTimePicker2.Text;

            itemReports = aStockOutManager.SalesStockOutsReport(fromDate,toDate);

            foreach (StockOut aItemReport in itemReports)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ((viewSalesBetweenTwoDatesListView.Items.Count + 1).ToString());
                item.SubItems.Add(aItemReport.ItemName);
                
                item.SubItems.Add(aItemReport.Quantity.ToString());
                viewSalesBetweenTwoDatesListView.Items.Add(item);
            }
        }      
    }
}
