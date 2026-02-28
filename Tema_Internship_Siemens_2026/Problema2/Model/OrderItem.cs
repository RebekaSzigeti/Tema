namespace SieMarket.Model
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }

        public OrderItem() { }

        public OrderItem(int id, Product product, int quantity)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            Id = id;
            Product = product;
            Quantity = quantity;
            PriceAtPurchase = product.UnitPrice;

        }

        public decimal TotalPrice()
        {
            return Quantity * PriceAtPurchase;
        }

    }
}
