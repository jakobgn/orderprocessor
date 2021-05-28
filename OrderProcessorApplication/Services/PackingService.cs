using System;

namespace OrderProcessorApplication.Services
{
    public class PackingService : IPackingService
    {
        public void GenerateDuplicatePackingSlip()
        {
            Console.WriteLine("GenerateDuplicatePackingSlip");
        }

        public void GeneratePackingSlip()
        {
            Console.WriteLine("GeneratePackingSlip");
        }
    }
}