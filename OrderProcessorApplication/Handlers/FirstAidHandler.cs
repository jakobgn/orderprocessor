using OrderProcessorApplication.Models;
using OrderProcessorApplication.Services;

namespace OrderProcessorApplication.Handlers
{
    public class FirstAidHandler : HandlerBase<Order>
    {
        private readonly IPackingService _packingService;

        public FirstAidHandler(IPackingService packingService)
        {
            _packingService = packingService;
        }
        public override void Process(Order order)
        {
            if (order.Product is Video && order.Product.Name.Equals("Learning to Ski"))
            {
                _packingService.GenerateFirstAidSlip();
            }
            base.Process(order);
        }
 
    }
}