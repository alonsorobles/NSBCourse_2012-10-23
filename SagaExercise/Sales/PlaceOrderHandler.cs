using System;
using NServiceBus;
using NServiceBus.Saga;
using Sales.Messages.Commands;
using Sales.Messages.Events;

namespace Sales
{
    public class OrderAcceptanceSaga : Saga<OrderAcceptanceSagaData>, IAmStartedByMessages<PlaceOrder>, IHandleMessages<CancelOrder>, IHandleTimeouts<AcceptOrder>
    {
        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<PlaceOrder>(data => data.OrderId, order => order.OrderId);
            ConfigureMapping<CancelOrder>(data => data.OrderId, order => order.OrderId);
        }
        
        public void Handle(PlaceOrder message)
        {
            Console.WriteLine("Order #{0} placed.", message.OrderId);
            Data.OrderId = message.OrderId;
            RequestUtcTimeout<AcceptOrder>(AcceptOrder.WaitTime);
        }

        public void Handle(CancelOrder message)
        {
            Data.Cancelled = true;
            if (Data.Accepted)
                Bus.Publish<IOrderCancelled>(cancelled => cancelled.OrderId = message.OrderId);
            Console.WriteLine("Order #{0} cancelled.", message.OrderId);
            MarkAsComplete();
        }

        public void Timeout(AcceptOrder state)
        {
            if (Data.Cancelled)
                return;
            Data.Accepted = true;
            Bus.Publish<IOrderAccepted>(accepted => accepted.OrderId = Data.OrderId);
            Console.WriteLine("Order #{0} accepted.", Data.OrderId);
        }
    }

    public class AcceptOrder
    {
        public readonly static TimeSpan WaitTime = TimeSpan.FromSeconds(15);
    }

    public class OrderAcceptanceSagaData : ISagaEntity
    {
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }
        public int OrderId { get; set; }
        public bool Accepted { get; set; }
        public bool Cancelled { get; set; }
    }
}