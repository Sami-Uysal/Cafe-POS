using System;
using System.Collections.Generic;
using System.Data;
using Cafe.UI.Concrete;
using MySql.Data.MySqlClient;

namespace Cafe.UI
{
    public class DataAccess
    {
        private readonly string connectionString;
        public DataAccess()
        {
            connectionString = "connectionString";
        }

        public List<Customer> GetCustomers(string searchText)
        {
            List<Customer> customers = new List<Customer>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM customers WHERE name LIKE @searchText";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string customerName = reader.GetString("name");
                            int tableNumber = reader.IsDBNull("table_number") ? -1 : reader.GetInt32("table_number");

                            Customer customer = new Customer(customerName, tableNumber);
                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }

        public List<Order> GetOrders(string searchText)
        {
            List<Order> orders = new List<Order>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                string query = "SELECT * FROM orders WHERE item_name LIKE @searchText";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader["item_name"].ToString();
                            int quantity = Convert.ToInt32(reader["quantity"]);
                            int tableNumber = Convert.ToInt32(reader["table_number"]);

                            Order order = new Order
                            {
                                ItemName = itemName,
                                Quantity = quantity,
                                TableNumber = tableNumber
                            };

                            orders.Add(order);
                        }
                    }

                    connection.Close();
                }

                return orders;
            }
        }




        public List<Item> GetItems(string searchText)
        {
            List<Item> items = new List<Item>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT name AS itemName, price AS itemPrice FROM items WHERE name LIKE @searchText";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader.GetString("itemName");
                            decimal itemPrice = reader.GetDecimal("itemPrice");

                            Item item = new Item
                            {
                                Name = itemName,
                                Price = itemPrice
                            };

                            items.Add(item);
                        }
                    }
                }
            }

            return items;
        }

        public List<Item> ShortItems(string sortColumn, string sortDirection)
        {
            List<Item> items = new List<Item>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"SELECT name, price FROM items ORDER BY {sortColumn} {sortDirection}";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader.GetString("Name");
                            decimal itemPrice = reader.GetDecimal("Price");

                            Item item = new Item
                            {
                                Name = itemName,
                                Price = itemPrice
                            };

                            items.Add(item);
                        }
                    }
                }
            }

            return items;
        }



        public List<int> GetTableNumbers()
        {
            List<int> tableNumbers = new List<int>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT DISTINCT table_number FROM customers";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tableNumber = reader.GetInt32("table_number");
                            tableNumbers.Add(tableNumber);
                        }
                    }
                }
            }

            return tableNumbers;
        }

        public void AddCustomer(string name, int tableNumber)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO customers (name, table_number) VALUES (@name, @tableNumber)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@tableNumber", tableNumber);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public bool AddOrder(string itemName, int quantity, int tableNumber)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string checkItemQuery = "SELECT COUNT(*) FROM items WHERE name = @itemName";
                using (MySqlCommand checkItemCommand = new MySqlCommand(checkItemQuery, connection))
                {
                    checkItemCommand.Parameters.AddWithValue("@itemName", itemName);
                    int itemCount = Convert.ToInt32(checkItemCommand.ExecuteScalar());
                    if (itemCount == 0)
                    {
                        return false;
                    }
                }

                string checkTableQuery = "SELECT COUNT(*) FROM customers WHERE table_number = @tableNumber";
                using (MySqlCommand checkTableCommand = new MySqlCommand(checkTableQuery, connection))
                {
                    checkTableCommand.Parameters.AddWithValue("@tableNumber", tableNumber);
                    int tableCount = Convert.ToInt32(checkTableCommand.ExecuteScalar());
                    if (tableCount == 0)
                    {
                        return false;
                    }
                }

                string query = "INSERT INTO orders (item_name, quantity, table_number, order_count) VALUES (@itemName, @quantity, @tableNumber, @orderCount)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@itemName", itemName);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@tableNumber", tableNumber);

                    
                    Random random = new Random();
                    int orderCount = random.Next(1, 100); 
                    command.Parameters.AddWithValue("@orderCount", orderCount);

                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return true;
            }
        }



        public void AddItem(string name, decimal price)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO items (name, price) VALUES (@name, @price)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@price", price);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void DeleteOrder(int tableNumber)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM orders WHERE table_number = @tableNumber";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tableNumber", tableNumber);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }


        public void DeleteCustomerByTable(int tableNumber)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM customers WHERE table_number = @tableNumber";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tableNumber", tableNumber);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }



    }
}
