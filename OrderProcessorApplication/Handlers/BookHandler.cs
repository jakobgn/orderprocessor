using OrderProcessorApplication.Models;
using OrderProcessorApplication.Services;

namespace OrderProcessorApplication.Handlers
{
    public class BookHandler : HandlerBase<Order>
    {
        private readonly IPackingService _packingService;

        public BookHandler(IPackingService packingService)
        {
            _packingService = packingService;
        }
        public override void Process(Order order)
        {
            if (order.Product is Book)
            {
                _packingService.GenerateDuplicatePackingSlip();
            }
            base.Process(order);
        }
 
    }
}