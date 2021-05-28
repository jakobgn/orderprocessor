using OrderProcessorApplication.Models;
using OrderProcessorApplication.Services;

namespace OrderProcessorApplication.Handlers
{
    public class EmailHandler : HandlerBase<Order>
    {
        private readonly IMembershipService _membershipService;

        public EmailHandler(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }
        public override void Process(Order order)
        {
            if (order.Product is MembershipActivation || order.Product is MembershipUpgrade)
            {
                _membershipService.SendEmail(order.Email);
            }
            base.Process(order);
        }
    }
}