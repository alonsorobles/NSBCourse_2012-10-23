using System;
using Billing.Messages.Events;
using NServiceBus;
using Sales.Messages.Events;

namespace Billing
{
    public class OrderAcceptedHandler : IHandleMessages<IOrderAccepted>
    {
        public IBus Bus { get; set; }

        public void Handle(IOrderAccepted message)
        {
            // I guess I could start a billing saga here. But it doesn't feel right. 
            var orderBilled = Bus.CreateInstance<IOrderBilled>(billed => billed.OrderId = message.OrderId);
            Bus.Publish(orderBilled);
            Console.WriteLine("Order #{0} billed.", orderBilled.OrderId);
            Console.WriteLine("========================================");
        }
    }
}