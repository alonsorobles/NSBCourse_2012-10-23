using System;
using Billing.Messages.Events;
using NServiceBus.Saga;
using Sales.Messages.Events;

namespace Shipping
{
    public class ShippingSaga : Saga<ShippingSagaData>, IAmStartedByMessages<IOrderAccepted>, IAmStartedByMessages<IOrderBilled>
    {
        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<IOrderAccepted>(saga => saga.OrderId, orderAccepted => orderAccepted.OrderId);
            ConfigureMapping<IOrderBilled>(saga => saga.OrderId, orderBilled => orderBilled.OrderId);
        }

        public void Handle(IOrderAccepted message)
        {
            Data.OrderId = message.OrderId;
            Data.OrderAccepted = true;
            Console.WriteLine("Received acceptance notification for order #{0}.", message.OrderId);
            ShipIfReady();
        }

        public void Handle(IOrderBilled message)
        {
            Data.OrderId = message.OrderId;
            Data.OrderBilled = true;
            Console.WriteLine("Received billing notification for order #{0}.", message.OrderId);
            ShipIfReady();
        }

        private void ShipIfReady()
        {
            if (!Data.OrderAccepted)
                Console.WriteLine("Waiting for acceptance notification for order #{0}.", Data.OrderId);
            else if (!Data.OrderBilled)
                Console.WriteLine("Waiting for billing notification for order #{0}.", Data.OrderId);
            else
            {
                Console.WriteLine("Now shipping order #{0}", Data.OrderId);
                MarkAsComplete();
            }
            Console.WriteLine("========================================");
        }
    }

    public class ShippingSagaData : ISagaEntity
    {
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }
        public int OrderId { get; set; }
        public bool OrderAccepted { get; set; }
        public bool OrderBilled { get; set; }
    }
}