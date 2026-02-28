using SieMarket.Model;
using SieMarket.Services;
using System;

namespace SieMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var c1 = new Customer(1, "Sarah");
            var c2 = new Customer(2, "John Doe");
            var c3 = new Customer(2, "John Doe");

            var p1 = new Product(101, "Laptop", 800m);
            var p2 = new Product(102, "Mouse", 20m);
            var p3 = new Product(103, "Monitor", 200m);
            var p4 = new Product(101, "Laptop", 800m);
            var p5 = new Product(102, "Mouse", 20m);


            var order1 = new Order(1, c1);
            order1.addItem(new OrderItem(1,p1, 1));


            var order2 = new Order(2, c2);
            order2.addItem(new OrderItem(2,p3, 2));
            order2.addItem(new OrderItem(3,p2, 2));

            var order3 = new Order(3, c3);
            order3.addItem(new OrderItem(4, p4, 1));
            order3.addItem(new OrderItem(5, p5, 4));


            var manager = new OrderManager();
            manager.AddOrder(order1);
            manager.AddOrder(order2);
            manager.AddOrder(order3);


            // 800 - 800*0.1 = 720
            Console.WriteLine($"Order 1 Final Price (with discount): {order1.FinalPrice()}");

            //2*200 + 2*20 = 440;    440 < 500 => final price = 440
            Console.WriteLine($"Order 2 Final Price (no discount): {order2.FinalPrice()}");

            //800 + 4*20 = 880 ; 880 - 880*01 = 792
            Console.WriteLine($"Order 3 Final Price (with discount): {order3.FinalPrice()}");

            // Sarah : 720
            // John Doe : 440 + 792 = 1232
            // top spender : John Doe
            Console.WriteLine($"Top Spender: {manager.GetTopSpender()}");


            var popular = manager.GetPopularProducts();
            Console.WriteLine("\nPopular Products:");
            foreach (var item in popular)
            {
                Console.WriteLine($"{item.Key.Name}: {item.Value} sold");
            }

        }
    }
}
