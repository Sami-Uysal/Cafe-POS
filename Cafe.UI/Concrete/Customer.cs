namespace Cafe.UI.Concrete
{
    public class Customer
    {
        public string customerName { get; set; }
        public int tableNumber { get; set; }

        public Customer(string name, int tableNumber)
        {
            this.customerName = name;
            this.tableNumber = tableNumber;
        }
    }
}