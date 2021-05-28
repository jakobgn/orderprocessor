using System;

namespace OrderProcessorApplication.Services
{
    public class MembershipService : IMembershipService
    {
        public void Activate()
        {
            Console.WriteLine("Activate membership");
        }

        public void Upgrade()
        {
            Console.WriteLine("Upgrade membership");
        }

        //TODO should be in an email service and include topic
        public void SendEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException(nameof(email));
            }
            Console.WriteLine("SendEmail to " + email);
        }
    }
}