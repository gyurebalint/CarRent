namespace CarRent.Views
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesPersonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rentedCarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dealsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewRentedCars = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(659, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carsToolStripMenuItem,
            this.customersToolStripMenuItem,
            this.salesPersonsToolStripMenuItem,
            this.rentedCarsToolStripMenuItem,
            this.dealsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // carsToolStripMenuItem
            // 
            this.carsToolStripMenuItem.Name = "carsToolStripMenuItem";
            this.carsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.carsToolStripMenuItem.Text = "Cars";
            this.carsToolStripMenuItem.Click += new System.EventHandler(this.carsToolStripMenuItem_Click);
            // 
            // customersToolStripMenuItem
            // 
            this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            this.customersToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.customersToolStripMenuItem.Text = "Customers";
            this.customersToolStripMenuItem.Click += new System.EventHandler(this.customersToolStripMenuItem_Click);
            // 
            // salesPersonsToolStripMenuItem
            // 
            this.salesPersonsToolStripMenuItem.Name = "salesPersonsToolStripMenuItem";
            this.salesPersonsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.salesPersonsToolStripMenuItem.Text = "SalesPersons";
            this.salesPersonsToolStripMenuItem.Click += new System.EventHandler(this.salesPersonsToolStripMenuItem_Click);
            // 
            // rentedCarsToolStripMenuItem
            // 
            this.rentedCarsToolStripMenuItem.Name = "rentedCarsToolStripMenuItem";
            this.rentedCarsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.rentedCarsToolStripMenuItem.Text = "RentedCars";
            this.rentedCarsToolStripMenuItem.Click += new System.EventHandler(this.rentedCarsToolStripMenuItem_Click);
            // 
            // dealsToolStripMenuItem
            // 
            this.dealsToolStripMenuItem.Name = "dealsToolStripMenuItem";
            this.dealsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.dealsToolStripMenuItem.Text = "Deals";
            this.dealsToolStripMenuItem.Click += new System.EventHandler(this.dealsToolStripMenuItem_Click);
            // 
            // listViewRentedCars
            // 
            this.listViewRentedCars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewRentedCars.FullRowSelect = true;
            this.listViewRentedCars.HideSelection = false;
            this.listViewRentedCars.Location = new System.Drawing.Point(42, 76);
            this.listViewRentedCars.Name = "listViewRentedCars";
            this.listViewRentedCars.Size = new System.Drawing.Size(579, 244);
            this.listViewRentedCars.TabIndex = 9;
            this.listViewRentedCars.UseCompatibleStateImageBehavior = false;
            this.listViewRentedCars.View = System.Windows.Forms.View.Details;
            this.listViewRentedCars.SelectedIndexChanged += new System.EventHandler(this.listViewRentedCars_SelectedIndexChanged);
            this.listViewRentedCars.DoubleClick += new System.EventHandler(this.listViewRentedCars_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "RentedCarID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Car";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "SalesPerson";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Start Date";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "End Date";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Is Insured";
            this.columnHeader6.Width = 500;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 389);
            this.Controls.Add(this.listViewRentedCars);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesPersonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rentedCarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dealsToolStripMenuItem;
        private System.Windows.Forms.ListView listViewRentedCars;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

