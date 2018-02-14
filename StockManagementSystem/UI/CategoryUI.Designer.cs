namespace StockManagementSystem.UI
{
    partial class CategoryUi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.categoryNameTextBox = new System.Windows.Forms.TextBox();
            this.categorySaveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.categoryListView = new System.Windows.Forms.ListView();
            this.siColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hiddenCategoryIdLabel = new System.Windows.Forms.Label();
            this.categoryIdLabel = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // categoryNameTextBox
            // 
            this.categoryNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.categoryNameTextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryNameTextBox.Location = new System.Drawing.Point(133, 71);
            this.categoryNameTextBox.Name = "categoryNameTextBox";
            this.categoryNameTextBox.Size = new System.Drawing.Size(307, 27);
            this.categoryNameTextBox.TabIndex = 0;
            // 
            // categorySaveButton
            // 
            this.categorySaveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.categorySaveButton.BackColor = System.Drawing.Color.DarkCyan;
            this.categorySaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categorySaveButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorySaveButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.categorySaveButton.Location = new System.Drawing.Point(349, 126);
            this.categorySaveButton.Name = "categorySaveButton";
            this.categorySaveButton.Size = new System.Drawing.Size(91, 35);
            this.categorySaveButton.TabIndex = 1;
            this.categorySaveButton.Text = "Save";
            this.categorySaveButton.UseVisualStyleBackColor = false;
            this.categorySaveButton.Click += new System.EventHandler(this.categorySaveButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name";
            // 
            // categoryListView
            // 
            this.categoryListView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.categoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.siColumnHeader,
            this.columnHeader2});
            this.categoryListView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryListView.FullRowSelect = true;
            this.categoryListView.GridLines = true;
            this.categoryListView.Location = new System.Drawing.Point(133, 186);
            this.categoryListView.Name = "categoryListView";
            this.categoryListView.Size = new System.Drawing.Size(333, 150);
            this.categoryListView.TabIndex = 12;
            this.categoryListView.UseCompatibleStateImageBehavior = false;
            this.categoryListView.View = System.Windows.Forms.View.Details;
            this.categoryListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.categoryListView_MouseDoubleClick);
            // 
            // siColumnHeader
            // 
            this.siColumnHeader.Text = "SI";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Category Name";
            this.columnHeader2.Width = 269;
            // 
            // hiddenCategoryIdLabel
            // 
            this.hiddenCategoryIdLabel.Location = new System.Drawing.Point(0, 0);
            this.hiddenCategoryIdLabel.Name = "hiddenCategoryIdLabel";
            this.hiddenCategoryIdLabel.Size = new System.Drawing.Size(100, 23);
            this.hiddenCategoryIdLabel.TabIndex = 13;
            // 
            // categoryIdLabel
            // 
            this.categoryIdLabel.AutoSize = true;
            this.categoryIdLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryIdLabel.Location = new System.Drawing.Point(385, 9);
            this.categoryIdLabel.Name = "categoryIdLabel";
            this.categoryIdLabel.Size = new System.Drawing.Size(112, 17);
            this.categoryIdLabel.TabIndex = 0;
            this.categoryIdLabel.Text = "hiddenCategoryId";
            this.categoryIdLabel.Visible = false;
            // 
            // resetButton
            // 
            this.resetButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.resetButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(230, 126);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(91, 35);
            this.resetButton.TabIndex = 14;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // CategoryUi
            // 
            this.AcceptButton = this.categorySaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 363);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.categoryListView);
            this.Controls.Add(this.categorySaveButton);
            this.Controls.Add(this.categoryNameTextBox);
            this.Controls.Add(this.hiddenCategoryIdLabel);
            this.Controls.Add(this.categoryIdLabel);
            this.Controls.Add(this.label2);
            this.Name = "CategoryUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup CategoryUI";
            this.Load += new System.EventHandler(this.CategoryUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox categoryNameTextBox;
        private System.Windows.Forms.Button categorySaveButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView categoryListView;
        private System.Windows.Forms.ColumnHeader siColumnHeader;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label hiddenCategoryIdLabel;
        private System.Windows.Forms.Label categoryIdLabel;
        private System.Windows.Forms.Button resetButton;
    }
}

