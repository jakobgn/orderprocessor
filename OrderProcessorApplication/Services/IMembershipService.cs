namespace OrderProcessorApplication.Services
{
    public interface IMembershipService
    {
        void Activate();
        void Upgrade();
        void SendEmail(string email);
    }
}