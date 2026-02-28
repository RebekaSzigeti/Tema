namespace SieMarket.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public Customer() { }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
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

            Customer? other = obj as Customer;
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id;
        }



    }
}
