using OrderProcessorApplication.Handlers;
using OrderProcessorApplication.Models;
using OrderProcessorApplication.Services;

namespace OrderProcessorApplication
{
    public class OrderProcessorFactory
    {
        private readonly PackingService _packingService;

        public OrderProcessorFactory()
        {
            _packingService = new PackingService();
        }
        public IHandler<Order> CreateRules()
        {
            var physicalProductHandler = new PhysicalProductHandler(_packingService);
            var bookHandler = new BookHandler(_packingService);

            physicalProductHandler.SetNext(bookHandler);
            return physicalProductHandler;
        }
    }
}