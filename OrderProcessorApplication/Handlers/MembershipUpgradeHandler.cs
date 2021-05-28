using OrderProcessorApplication.Models;
using OrderProcessorApplication.Services;

namespace OrderProcessorApplication.Handlers
{
    public class MembershipUpgradeHandler : HandlerBase<Order>
    {
        private readonly IMembershipService _membershipService;

        public MembershipUpgradeHandler(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }
        public override void Process(Order order)
        {
            if (order.Product is MembershipUpgrade)
            {
                _membershipService.Upgrade();
                _membershipService.SendEmail(order.Email);
            }
            base.Process(order);
        }
    }
}