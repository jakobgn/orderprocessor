namespace OrderProcessorApplication.Models
{
    public class Book : Product
    {
        public Book(string name) : base(name)
        {
            IsPhysical = true;
        }
    }
}