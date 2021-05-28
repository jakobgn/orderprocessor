using System;
using OrderProcessorApplication.Models;

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

    public interface IPackingService
    {
        void GenerateDuplicatePackingSlip();
    }

    public class PackingService : IPackingService
    {
        public void GenerateDuplicatePackingSlip()
        {
            Console.WriteLine("GenerateDuplicatePackingSlip");
        }
    }
}