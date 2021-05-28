using OrderProcessorApplication.Handlers;
using OrderProcessorApplication.Models;
using OrderProcessorApplication.Services;

namespace OrderProcessorApplication
{
    public class OrderProcessorFactory
    {
        private readonly PackingService _packingService;
        private readonly MembershipService _membershipService;

        public OrderProcessorFactory()
        {
            _packingService = new PackingService();
            _membershipService = new MembershipService();
        }
        public IHandler<Order> CreateRules()
        {
            var physicalProductHandler = new PhysicalProductHandler(_packingService);
            var bookHandler = new BookHandler(_packingService);
            var membershipActivationHandler = new MembershipActivationHandler(_membershipService);
            var membershipUpgradeHandler = new MembershipUpgradeHandler(_membershipService);
            var emailHandler = new EmailHandler(_membershipService);

            physicalProductHandler.SetNext(bookHandler);
            bookHandler.SetNext(membershipActivationHandler);
            membershipActivationHandler.SetNext(membershipUpgradeHandler);
            membershipUpgradeHandler.SetNext(emailHandler);

            return physicalProductHandler;
        }
    }
}