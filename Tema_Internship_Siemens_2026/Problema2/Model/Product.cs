namespace SieMarket.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal UnitPrice { get; set; }

        public Product() { }

        public Product(int id, string name, decimal unitPrice)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            Product? other = obj as Product;

            if (other == null)
            {
                return false;
            }
            return this.Id == other.Id;
        }


    }
}
