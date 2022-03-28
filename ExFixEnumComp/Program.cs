using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using ExFixEnumComp.Entities.Enums;
using ExFixEnumComp.Entities;

namespace ExFixEnumComp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Bitrh date: (DD/MM/YYYY)");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Client client = new Client(name, email, date);
            Console.WriteLine("Enter order data: ");
            //DateTime now = DateTime.Now;
            Console.Write("Satuts: ");
            //OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine()); // Core
            Enum.TryParse<OrderStatus>(Console.ReadLine(), out OrderStatus status); //.Net
            Order order = new Order(DateTime.Now, status, client);
            Console.Write("How many items to this order? ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Product product = new Product(productName, price);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                OrderItem orderItem = new OrderItem(quantity, price, product);
                order.AddItem(orderItem);
            }
            Console.WriteLine("Order Sumary: ");
            Console.WriteLine();
            Console.WriteLine(order);
        }
    }
}
