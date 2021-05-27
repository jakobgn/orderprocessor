namespace OrderProcessorApplication.Models
{
    public class Video : Product
    {
        public Video(string name) : base(name)
        {
            IsPhysical = false;
        }
    }
}