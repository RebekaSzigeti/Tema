namespace SieMarket.Model
{
    public class Order
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public List<OrderItem> Items { get; }
        public DateTime OrderDate { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
            OrderDate = DateTime.Now;
        }

        public Order(int id, Customer customer, DateTime? orderDate = null)
        {
            Id = id;
            Customer = customer;
            Items = new List<OrderItem>();
            OrderDate = orderDate ?? DateTime.Now;
        }

        public Order(int id, Customer customer, List<OrderItem> list, DateTime? orderDate = null)
        {
            Id = id;
            Customer = customer;
            Items = new List<OrderItem>(list);
            OrderDate = orderDate ?? DateTime.Now;
        }

        public void addItem(OrderItem item)
        {
            Items.Add(item);
        }

        //2.2
        public decimal FinalPrice()
        {
            decimal total = 0;
            foreach (OrderItem item in Items)
            {
                total += item.TotalPrice();
            }

            if (total > 500)
            {
                total = total - total * 0.1m;
            }

            return total;
        }


    }
}
