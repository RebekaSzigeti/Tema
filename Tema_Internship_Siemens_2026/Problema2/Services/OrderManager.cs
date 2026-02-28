using SieMarket.Model;

namespace SieMarket.Services
{
    public class OrderManager
    {
        public List<Order> Orders { get; }

        public OrderManager()
        {
            Orders = new List<Order>();
        }

        public OrderManager(List<Order> orders)
        {
            Orders = new List<Order>(orders);
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        //2.3
        public string GetTopSpender()
        {

            if (Orders.Count == 0)
            {
                return "No orders found";
            }

            Dictionary<Customer, decimal> customerSpendings = new Dictionary<Customer, decimal>();


            foreach (Order order in Orders)
            {
                if (order.Customer == null) continue;

                if (customerSpendings.ContainsKey(order.Customer))
                {
                    customerSpendings[order.Customer] += order.FinalPrice();
                }
                else
                {
                    customerSpendings[order.Customer] = order.FinalPrice();
                }

            }

            Customer? topSpender = null;
            decimal maxSpent = -1;

            foreach (var entry in customerSpendings)
            {
                if (entry.Value > maxSpent)
                {
                    maxSpent = entry.Value;
                    topSpender = entry.Key;
                }
            }

            if (topSpender == null)
            {
                return "No spender found";
            }

            if (topSpender.Name == null)
            {
                return "Unknown customer";
            }

            return topSpender.Name;

        }

        //2.4 (Bonus)
        public Dictionary<Product, int> GetPopularProducts()
        {
            Dictionary<Product, int> productStats = new Dictionary<Product, int>();
            if (Orders.Count == 0) return productStats;

            foreach (var order in Orders)
            {
                foreach (var item in order.Items)
                {
                    Product? product = item.Product;
                    if (product == null) continue;
                    if (productStats.ContainsKey(product))
                    {
                        productStats[product] += item.Quantity;
                    }
                    else
                    {
                        productStats[product] = item.Quantity;
                    }
                }
            }


            return productStats;
        }

    }
}
