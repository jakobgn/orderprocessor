namespace OrderProcessorApplication.Models
{
    public class NonPhysicalProduct : Product
    {
        public NonPhysicalProduct()
        {
            IsPhysical = false;
        }
    }
}