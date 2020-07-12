namespace CarRent.Views
{
    partial class RentedCarsForm
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
            this.components = new System.ComponentModel.Container();
            this.comboCar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerStartDay = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxInsurance = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listViewRentedCars = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listViewDeals = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboCar
            // 
            this.comboCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCar.FormattingEnabled = true;
            this.comboCar.Location = new System.Drawing.Point(15, 249);
            this.comboCar.Name = "comboCar";
            this.comboCar.Size = new System.Drawing.Size(203, 21);
            this.comboCar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Car";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start Day";
            // 
            // dateTimePickerStartDay
            // 
            this.dateTimePickerStartDay.Location = new System.Drawing.Point(18, 304);
            this.dateTimePickerStartDay.Name = "dateTimePickerStartDay";
            this.dateTimePickerStartDay.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStartDay.TabIndex = 3;
            // 
            // dateTimePickerEndDay
            // 
            this.dateTimePickerEndDay.Location = new System.Drawing.Point(18, 360);
            this.dateTimePickerEndDay.Name = "dateTimePickerEndDay";
            this.dateTimePickerEndDay.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEndDay.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "End Day";
            // 
            // checkBoxInsurance
            // 
            this.checkBoxInsurance.AutoSize = true;
            this.checkBoxInsurance.Location = new System.Drawing.Point(18, 404);
            this.checkBoxInsurance.Name = "checkBoxInsurance";
            this.checkBoxInsurance.Size = new System.Drawing.Size(141, 17);
            this.checkBoxInsurance.TabIndex = 6;
            this.checkBoxInsurance.Text = "Do you want insurance?";
            this.checkBoxInsurance.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(467, 398);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.listViewRentedCars.Location = new System.Drawing.Point(467, 29);
            this.listViewRentedCars.Name = "listViewRentedCars";
            this.listViewRentedCars.Size = new System.Drawing.Size(426, 351);
            this.listViewRentedCars.TabIndex = 8;
            this.listViewRentedCars.UseCompatibleStateImageBehavior = false;
            this.listViewRentedCars.View = System.Windows.Forms.View.Details;
            this.listViewRentedCars.SelectedIndexChanged += new System.EventHandler(this.listViewRentedCars_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "RentedCarID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Car";
            this.columnHeader2.Width = 56;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Deal";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Start Date";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "End Date";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Is Insured";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(588, 398);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Deal";
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(CarRent.DataStructures.Customer);
            // 
            // listViewDeals
            // 
            this.listViewDeals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.listViewDeals.FullRowSelect = true;
            this.listViewDeals.HideSelection = false;
            this.listViewDeals.Location = new System.Drawing.Point(12, 29);
            this.listViewDeals.Name = "listViewDeals";
            this.listViewDeals.Size = new System.Drawing.Size(449, 190);
            this.listViewDeals.TabIndex = 12;
            this.listViewDeals.UseCompatibleStateImageBehavior = false;
            this.listViewDeals.View = System.Windows.Forms.View.Details;
            this.listViewDeals.SelectedIndexChanged += new System.EventHandler(this.listViewDeals_SelectedIndexChanged);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "DealID";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Created";
            this.columnHeader8.Width = 82;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Customer Name";
            this.columnHeader9.Width = 108;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Customer ID number";
            this.columnHeader10.Width = 126;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "SalesPerson Name";
            // 
            // RentedCarsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 446);
            this.Controls.Add(this.listViewDeals);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.listViewRentedCars);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.checkBoxInsurance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerEndDay);
            this.Controls.Add(this.dateTimePickerStartDay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboCar);
            this.Name = "RentedCarsForm";
            this.Text = "RentedCarsForm";
            this.Load += new System.EventHandler(this.RentedCarsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboCar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDay;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxInsurance;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView listViewRentedCars;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView listViewDeals;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
    }
}