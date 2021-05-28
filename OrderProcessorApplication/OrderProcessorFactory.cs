using OrderProcessorApplication.Handlers;
using OrderProcessorApplication.Models;

namespace OrderProcessorApplication
{
    public class OrderProcessorFactory
    {
        public IHandler<Order> CreateRules()
        {
            var physicalProductHandler = new PhysicalProductHandler();
            var bookHandler = new BookHandler(new PackingService());

            physicalProductHandler.SetNext(bookHandler);
            return physicalProductHandler;
        }
    }
}