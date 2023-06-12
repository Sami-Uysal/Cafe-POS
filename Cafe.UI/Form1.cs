using Cafe.UI.Concrete;
namespace Cafe.UI
{
    public partial class Form1 : Form
    {
        private DataAccess dataAccess;
        private List<Customer> customers;
        private List<Order> orders;
        private List<Item> items;
        private Dictionary<int, List<Order>> ordersByTable;
        private List<RadioButton> radioButtons = new List<RadioButton>();

        public Form1()
        {
            InitializeComponent();

            dataAccess = new DataAccess();
            customers = new List<Customer>();
            orders = new List<Order>();
            items = new List<Item>();
            ordersByTable = new Dictionary<int, List<Order>>();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();


            AddRadioButton("Name (ASC)", "name ASC");
            AddRadioButton("Name (DESC)", "name DESC");
            AddRadioButton("Price (ASC)", "price ASC");
            AddRadioButton("Price (DESC)", "price DESC");

            radioButtons[0].Checked = true;


        }


        private async Task LoadDataAsync()
        {
            await Task.Run(() =>
            {
                LoadCustomers();
                LoadOrders();
                LoadItems();
            });
        }

        private void LoadCustomers()
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            customers = dataAccess.GetCustomers(searchText);

            this.Invoke((MethodInvoker)delegate
            {
                dgvCustomers.DataSource = customers;

                cmbTableNumber2.Items.Clear();

                List<int> tableNumbers = dataAccess.GetTableNumbers();
                object[] tableNumbersArray = tableNumbers.Cast<object>().ToArray();

                cmbTableNumber2.Items.AddRange(tableNumbersArray);
            });
        }



        private void LoadOrders()
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            orders = dataAccess.GetOrders(searchText);

            this.Invoke((MethodInvoker)delegate
            {
                dgvOrders.DataSource = orders;

                ordersByTable.Clear();
                foreach (Order order in orders)
                {
                    if (ordersByTable.ContainsKey(order.TableNumber))
                    {
                        ordersByTable[order.TableNumber].Add(order);
                    }
                    else
                    {
                        ordersByTable[order.TableNumber] = new List<Order> { order };
                    }
                }
            });

        }

        private void LoadItems()
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            items = dataAccess.GetItems(searchText);

            this.Invoke((MethodInvoker)delegate
            {
                dgvItems.DataSource = items;

                cmbProductName.Items.Clear();
                cmbProductName.Items.AddRange(items.Select(item => item.Name).ToArray());
            });
        }




        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string name = txtCustomerName.Text.Trim();
            int tableNumber = Convert.ToInt32(nudTableNumber.Value);

            dataAccess.AddCustomer(name, tableNumber);
            LoadCustomers();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            string itemName = cmbProductName.SelectedItem?.ToString().Trim();
            int quantity = Convert.ToInt32(nudQuantity.Value);
            int tableNumber = Convert.ToInt32(cmbTableNumber2.SelectedItem);

            if (string.IsNullOrEmpty(itemName))
            {
                MessageBox.Show("Please select a product name.");
                return;
            }

            bool orderAdded = dataAccess.AddOrder(itemName, quantity, tableNumber);
            if (orderAdded)
            {
                LoadOrders();
            }
            else
            {
                MessageBox.Show("Invalid order. Please select a valid table number.", "Error");
            }
        }





        private void btnCalculateBill_Click(object sender, EventArgs e)
        {
            CalculateBillsAndDisplay();

        }

        private void CalculateBillsAndDisplay()
        {
            cmbTableNumber.Items.Clear();

            Dictionary<int, decimal> billByTable = new Dictionary<int, decimal>();

            foreach (var tableOrders in ordersByTable)
            {
                int tableNumber = tableOrders.Key;
                decimal totalBill = CalculateBillForTable(tableOrders.Value);
                billByTable[tableNumber] = totalBill;

                cmbTableNumber.Items.Add(tableNumber);
            }

            if (billByTable.Count == 0)
            {
                MessageBox.Show("There are no orders available. Please create an order.", "Error");
                return;
            }

            string billText = string.Join(Environment.NewLine, billByTable.Select(kv => $"Table {kv.Key}: {kv.Value} $"));
            MessageBox.Show(billText, "Total Cost");
        }


        private decimal CalculateBillForTable(List<Order> tableOrders)
        {
            decimal totalBill = 0;

            foreach (Order order in tableOrders)
            {
                Item item = items.Find(i => i.Name == order.ItemName);
                if (item != null)
                {
                    totalBill += item.Price * order.Quantity;
                }
            }

            return totalBill;
        }


        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string itemName = txtItemName2.Text;
            decimal price = 0;

            if (!decimal.TryParse(txtItemPrice.Text, out price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            if (string.IsNullOrEmpty(itemName))
            {
                MessageBox.Show("Please enter a product name.");
                return;
            }

            dataAccess.AddItem(itemName, price);
            LoadItems();
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadOrders();
            LoadItems();
        }

        private void btnAccountPayment_Click(object sender, EventArgs e)
        {
            if (cmbTableNumber.SelectedItem == null)
            {
                MessageBox.Show("Please select the table for which you want to make a payment.", "Error");
                return;
            }

            int selectedTableNumber = (int)cmbTableNumber.SelectedItem;

            if (!ordersByTable.ContainsKey(selectedTableNumber))
            {
                MessageBox.Show("There are no orders available at the selected table.", "Error");
                return;
            }

            List<Order> tableOrders = ordersByTable[selectedTableNumber];
            PayForTable(selectedTableNumber, tableOrders);

        }

        private void PayForTable(int tableNumber, List<Order> tableOrders)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to make a payment for table {tableNumber}?", "Payment Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dataAccess.DeleteOrder(tableNumber);
                dataAccess.DeleteCustomerByTable(tableNumber);

                orders.RemoveAll(order => order.TableNumber == tableNumber);
                ordersByTable.Remove(tableNumber);

                MessageBox.Show($"Payment received for table {tableNumber}.", "Payment Completed.");
                LoadCustomers();
                LoadOrders();
            }
        }


        private void AddRadioButton(string text, string tag)
        {
            RadioButton radioButton = new RadioButton();
            radioButton.Text = text;
            radioButton.Tag = tag;
            radioButton.AutoSize = true;
            radioButton.CheckedChanged += RadioButton_CheckedChanged;

            flowLayoutPanel1.Controls.Add(radioButton);
            radioButtons.Add(radioButton);
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                string sortColumnAndDirection = radioButton.Tag.ToString();
                string sortColumn = sortColumnAndDirection.Split(' ')[0];
                string sortDirection = sortColumnAndDirection.Split(' ')[1];

                items = dataAccess.ShortItems(sortColumn, sortDirection);
                LoadItems();
            }
        }

    }
}
