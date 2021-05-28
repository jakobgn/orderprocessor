using System;
using OrderProcessorApplication.Models;

namespace OrderProcessorApplication.Handlers
{
    public class PhysicalProductHandler : HandlerBase<Order>
    {
        public override void Process(Order order)
        {
            if (order.Product.IsPhysical)
            {
                GeneratePackingSlip();
            }
            base.Process(order);
        }

        private void GeneratePackingSlip()
        {
            Console.WriteLine("GeneratePackingSlip");
        }
    }
}