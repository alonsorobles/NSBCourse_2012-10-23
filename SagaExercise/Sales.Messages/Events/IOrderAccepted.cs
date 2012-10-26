using NServiceBus;

namespace Sales.Messages.Events
{
    public interface IOrderAccepted : IEvent
    {
        int OrderId { get; set; }
    }
}