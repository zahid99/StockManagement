using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class CompanyUI : Form
    {
        public CompanyUI()
        {
            InitializeComponent();
            
        }

        CompanyManager aCompanyManager = new CompanyManager();
        public void CompanyListView()
        {
            companyListView.Items.Clear();
            List<Company> companies = aCompanyManager.GetAllCompany();
            foreach (Company company in companies)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ((companyListView.Items.Count + 1).ToString());
                item.SubItems.Add(company.CompanyName);
                item.Tag = company;
                companyListView.Items.Add(item);
            }
        }

        

        private void companySaveButton_Click(object sender, EventArgs e)
        {

            Company aCompany=new Company();
            aCompany.CompanyName = companyNameTextBox.Text;
            if (companySaveButton.Text=="Save")
            {
                string message = aCompanyManager.SaveCompany(aCompany);
                MessageBox.Show(message);
            }
            else
            {
                aCompany.CompanyId = Convert.ToInt32(hiddenCompanyLabel.Text);
                string message = aCompanyManager.UpdateCompany(aCompany);
                MessageBox.Show(message);
            }
            
            CompanyListView();
        }

        private void companyListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedItem = companyListView.SelectedItems[0];
            Company company = (Company) selectedItem.Tag;
           
            if (company!=null)
            {
                companyNameTextBox.Text = company.CompanyName;
                hiddenCompanyLabel.Text = company.CompanyId.ToString(); 
            }
            companySaveButton.Text = "Update";
        }

        private void CompanyUI_Load(object sender, EventArgs e)
        {
            CompanyListView();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            companyNameTextBox.Text = "";
            companySaveButton.Text = "Save";
        }

    }
}
