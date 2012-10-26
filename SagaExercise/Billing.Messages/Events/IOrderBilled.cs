using NServiceBus;

namespace Billing.Messages.Events
{
    public interface IOrderBilled : IEvent
    {
        int OrderId { get; set; }
    }
}