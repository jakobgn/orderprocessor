﻿using System;
using OrderProcessorApplication.Models;
using OrderProcessorApplication.Services;

namespace OrderProcessorApplication.Handlers
{
    public class CommissionHandler : HandlerBase<Order>
    {
        public override void Process(Order order)
        {
            if (order.Product is Book || order.Product is PhysicalProduct)
            {
                Console.WriteLine("Call payment service and add commision to agent");
            }
            base.Process(order);
        }
 
    }
}