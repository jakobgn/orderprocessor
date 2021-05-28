using OrderProcessorApplication.Models;
using OrderProcessorApplication.Services;

namespace OrderProcessorApplication.Handlers
{
    public class MembershipActivationHandler : HandlerBase<Order>
    {
        private readonly IMembershipService _membershipService;

        public MembershipActivationHandler(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }
        public override void Process(Order order)
        {
            if (order.Product is MembershipActivation)
            {
                _membershipService.Activate();
            }
            base.Process(order);
        }
    }
}