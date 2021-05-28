namespace OrderProcessorApplication.Services
{
    public interface IPackingService
    {
        void GenerateDuplicatePackingSlip();
        void GeneratePackingSlip();

        void GenerateFirstAidSlip();
    }
}