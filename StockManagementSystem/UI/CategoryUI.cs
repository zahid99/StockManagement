using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class CategoryUi : Form
    {
        public CategoryUi()
        {
            InitializeComponent();
      
        }

        CategoryManager aManager = new CategoryManager();

        public void CategoryListView()
        {
            categoryListView.Items.Clear();
            List<Category> category = aManager.GetAllCategory();
            foreach (Category aCategory in category)
            {
                ListViewItem item=new ListViewItem();
                item.Text = ((categoryListView.Items.Count + 1).ToString());               
                item.SubItems.Add(aCategory.CategoryName);
                item.Tag = aCategory;
                categoryListView.Items.Add(item);
            }
        }

       

        private void categorySaveButton_Click(object sender, EventArgs e)
        {
            Category category=new Category();

            category.CategoryName = categoryNameTextBox.Text;
            if (categorySaveButton.Text=="Save")
            {
                string message = aManager.SaveCategory(category);
                MessageBox.Show(message);
                categoryNameTextBox.Text = "";
            }
            else
            {
                category.categoryId =Convert.ToInt32( categoryIdLabel.Text);
                string message = aManager.UpdateCategory(category);
                MessageBox.Show(message);
                categoryNameTextBox.Text = "";
            }

            CategoryListView();
        }

      
        

        private void categoryListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedItem = categoryListView.SelectedItems[0];
            Category category = (Category) selectedItem.Tag;
            categoryNameTextBox.Text = category.CategoryName;
            categoryIdLabel.Text = category.categoryId.ToString();

            categorySaveButton.Text = "Update";

        }

        private void CategoryUI_Load(object sender, EventArgs e)
        {
            CategoryListView();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            categorySaveButton.Text = "Save";
            categoryNameTextBox.Text = "";
            categoryIdLabel.Text = null;
        }
    }
}
