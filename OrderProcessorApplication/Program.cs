using System;
using OrderProcessorApplication.Models;

namespace OrderProcessorApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new OrderProcessor();
            var order = Order.Create(new Book("Harry Potter"));
            processor.Process(order);
        }
    }
}
