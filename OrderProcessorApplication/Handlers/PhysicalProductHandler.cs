using OrderProcessorApplication.Models;
using OrderProcessorApplication.Services;

namespace OrderProcessorApplication.Handlers
{
    public class PhysicalProductHandler : HandlerBase<Order>
    {
        private readonly IPackingService _packingService;

        public PhysicalProductHandler(IPackingService packingService)
        {
            _packingService = packingService;
        }
        public override void Process(Order order)
        {
            if (order.Product.IsPhysical)
            {
                _packingService.GeneratePackingSlip();
            }
            base.Process(order);
        }
    }
}