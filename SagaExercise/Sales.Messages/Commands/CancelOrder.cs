using NServiceBus;

namespace Sales.Messages.Commands
{
    public class CancelOrder : ICommand
    {
        public int OrderId { get; set; }
    }
}