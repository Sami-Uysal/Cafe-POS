namespace Cafe.UI
{
    partial class Form1
    {
        private DataGridView dgvCustomers;
        private DataGridView dgvOrders;
        private DataGridView dgvItems;
        private TextBox txtSearch;
        private Label label1;
        private GroupBox groupBox1;
        private Button btnAddCustomer;
        private NumericUpDown nudTableNumber;
        private TextBox txtCustomerName;
        private Label label3;
        private Label label2;
        private GroupBox groupBox2;
        private Button btnAddOrder;
        private NumericUpDown nudQuantity;
        private Label label5;
        private Label label6;
        private GroupBox groupBox3;
        private Button btnAddItem;
        private TextBox txtItemPrice;
        private TextBox txtItemName2;
        private Label label4;
        private Label label7;
        private Button btnCalculateBill;
        private Button btnSearch;


        private void InitializeComponent()
        {
            dgvCustomers = new DataGridView();
            dgvOrders = new DataGridView();
            dgvItems = new DataGridView();
            txtSearch = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            btnAddCustomer = new Button();
            nudTableNumber = new NumericUpDown();
            txtCustomerName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            cmbProductName = new ComboBox();
            label9 = new Label();
            cmbTableNumber2 = new ComboBox();
            btnAddOrder = new Button();
            nudQuantity = new NumericUpDown();
            label5 = new Label();
            label6 = new Label();
            groupBox3 = new GroupBox();
            btnAddItem = new Button();
            txtItemPrice = new TextBox();
            txtItemName2 = new TextBox();
            label4 = new Label();
            label7 = new Label();
            btnCalculateBill = new Button();
            btnSearch = new Button();
            btnAccountPayment = new Button();
            cmbTableNumber = new ComboBox();
            label8 = new Label();
            label10 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTableNumber).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(10, 57);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.RowTemplate.Height = 24;
            dgvCustomers.Size = new Size(383, 207);
            dgvCustomers.TabIndex = 0;
            // 
            // dgvOrders
            // 
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(842, 57);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.RowTemplate.Height = 24;
            dgvOrders.Size = new Size(383, 207);
            dgvOrders.TabIndex = 1;
            // 
            // dgvItems
            // 
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(426, 57);
            dgvItems.Name = "dgvItems";
            dgvItems.RowHeadersWidth = 51;
            dgvItems.RowTemplate.Height = 24;
            dgvItems.Size = new Size(383, 207);
            dgvItems.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(934, 19);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(199, 23);
            txtSearch.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(843, 22);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 4;
            label1.Text = "Search (Name):";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddCustomer);
            groupBox1.Controls.Add(nudTableNumber);
            groupBox1.Controls.Add(txtCustomerName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(10, 270);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(383, 163);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add Customer";
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(130, 112);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(94, 29);
            btnAddCustomer.TabIndex = 4;
            btnAddCustomer.Text = "Add";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // nudTableNumber
            // 
            nudTableNumber.Location = new Point(130, 76);
            nudTableNumber.Name = "nudTableNumber";
            nudTableNumber.Size = new Size(94, 23);
            nudTableNumber.TabIndex = 3;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(130, 38);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(218, 23);
            txtCustomerName.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 78);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 1;
            label3.Text = "Table Number:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 40);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 0;
            label2.Text = "Customer Name:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbProductName);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(cmbTableNumber2);
            groupBox2.Controls.Add(btnAddOrder);
            groupBox2.Controls.Add(nudQuantity);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(842, 270);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(383, 163);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Add Order";
            // 
            // cmbProductName
            // 
            cmbProductName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductName.FormattingEnabled = true;
            cmbProductName.Location = new Point(130, 37);
            cmbProductName.Name = "cmbProductName";
            cmbProductName.Size = new Size(216, 23);
            cmbProductName.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(251, 79);
            label9.Name = "label9";
            label9.Size = new Size(37, 15);
            label9.TabIndex = 14;
            label9.Text = "Table:";
            // 
            // cmbTableNumber2
            // 
            cmbTableNumber2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTableNumber2.FormattingEnabled = true;
            cmbTableNumber2.Location = new Point(295, 75);
            cmbTableNumber2.Name = "cmbTableNumber2";
            cmbTableNumber2.Size = new Size(51, 23);
            cmbTableNumber2.TabIndex = 13;
            // 
            // btnAddOrder
            // 
            btnAddOrder.Location = new Point(130, 112);
            btnAddOrder.Name = "btnAddOrder";
            btnAddOrder.Size = new Size(94, 29);
            btnAddOrder.TabIndex = 4;
            btnAddOrder.Text = "Add";
            btnAddOrder.UseVisualStyleBackColor = true;
            btnAddOrder.Click += btnAddOrder_Click;
            // 
            // nudQuantity
            // 
            nudQuantity.Location = new Point(130, 76);
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(94, 23);
            nudQuantity.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 78);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 1;
            label5.Text = "Quantity:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 40);
            label6.Name = "label6";
            label6.Size = new Size(87, 15);
            label6.TabIndex = 0;
            label6.Text = "Product Name:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnAddItem);
            groupBox3.Controls.Add(txtItemPrice);
            groupBox3.Controls.Add(txtItemName2);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label7);
            groupBox3.Location = new Point(426, 270);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(383, 163);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Add Product";
            // 
            // btnAddItem
            // 
            btnAddItem.Location = new Point(130, 112);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(94, 29);
            btnAddItem.TabIndex = 4;
            btnAddItem.Text = "Add";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // txtItemPrice
            // 
            txtItemPrice.Location = new Point(130, 76);
            txtItemPrice.Name = "txtItemPrice";
            txtItemPrice.Size = new Size(94, 23);
            txtItemPrice.TabIndex = 3;
            // 
            // txtItemName2
            // 
            txtItemName2.Location = new Point(130, 38);
            txtItemName2.Name = "txtItemName2";
            txtItemName2.Size = new Size(218, 23);
            txtItemName2.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 78);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 1;
            label4.Text = "Price:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 40);
            label7.Name = "label7";
            label7.Size = new Size(87, 15);
            label7.TabIndex = 0;
            label7.Text = "Product Name:";
            // 
            // btnCalculateBill
            // 
            btnCalculateBill.Location = new Point(761, 479);
            btnCalculateBill.Name = "btnCalculateBill";
            btnCalculateBill.Size = new Size(84, 24);
            btnCalculateBill.TabIndex = 8;
            btnCalculateBill.Text = "Calculate";
            btnCalculateBill.UseVisualStyleBackColor = true;
            btnCalculateBill.Click += btnCalculateBill_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1146, 18);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(82, 22);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnAccountPayment
            // 
            btnAccountPayment.Location = new Point(989, 480);
            btnAccountPayment.Name = "btnAccountPayment";
            btnAccountPayment.Size = new Size(77, 23);
            btnAccountPayment.TabIndex = 10;
            btnAccountPayment.Text = "Payment";
            btnAccountPayment.UseVisualStyleBackColor = true;
            btnAccountPayment.Click += btnAccountPayment_Click;
            // 
            // cmbTableNumber
            // 
            cmbTableNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTableNumber.FormattingEnabled = true;
            cmbTableNumber.Location = new Point(932, 480);
            cmbTableNumber.Name = "cmbTableNumber";
            cmbTableNumber.Size = new Size(51, 23);
            cmbTableNumber.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(888, 484);
            label8.Name = "label8";
            label8.Size = new Size(37, 15);
            label8.TabIndex = 12;
            label8.Text = "Table:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(556, 1);
            label10.Name = "label10";
            label10.Size = new Size(81, 15);
            label10.TabIndex = 14;
            label10.Text = "Sort Products:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(426, 18);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(383, 33);
            flowLayoutPanel1.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1255, 520);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(cmbTableNumber);
            Controls.Add(btnAccountPayment);
            Controls.Add(btnSearch);
            Controls.Add(btnCalculateBill);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(txtSearch);
            Controls.Add(dgvItems);
            Controls.Add(dgvOrders);
            Controls.Add(dgvCustomers);
            Name = "Form1";
            Text = "Cafe Yönetim Sistemi";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTableNumber).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnAccountPayment;
        private ComboBox cmbTableNumber;
        private Label label8;
        private Label label9;
        private ComboBox cmbTableNumber2;
        private ComboBox cmbProductName;
        private Label label10;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
