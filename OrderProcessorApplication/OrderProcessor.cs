using OrderProcessorApplication.Handlers;
using OrderProcessorApplication.Models;

namespace OrderProcessorApplication
{
    public class OrderProcessor
    {
        private readonly IHandler<Order> _chain;

        public OrderProcessor()
        {
            var factory = new OrderProcessorFactory();
            _chain = factory.CreateRules();
        }

        public void Process(Order order)
        {
            _chain.Process(order);
        }
    }
}
