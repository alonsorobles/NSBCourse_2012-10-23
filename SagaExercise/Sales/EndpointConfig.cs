using System;
using System.Threading;
using NServiceBus;
using Sales.Messages.Events;

namespace Sales
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, IWantToRunAtStartup
    {
        public IBus Bus { get; set; }
        
        public void Run()
        {
            Console.WriteLine("This service will simulate the placement of many orders.");
            Console.WriteLine("It will start in about 5 seconds.");
            Console.WriteLine("And will keep sending until stopped.");

            Thread.Sleep(5000);

            var orderId = 0;
            while (true)
            {
                var tempOrderId = ++orderId;
                var orderAccepted = Bus.CreateInstance<IOrderAccepted>(accepted => accepted.OrderId = tempOrderId);
                Bus.Publish(orderAccepted);
                Console.WriteLine("Order #{0} accepted.", orderId);
                Console.WriteLine("========================================");
            }
        }

        public void Stop()
        {
            
        }
    }
}
