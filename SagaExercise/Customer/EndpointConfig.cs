using System;
using NServiceBus;
using Sales.Messages.Commands;

namespace Customer
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client, IWantToRunAtStartup
    {
        public IBus Bus { get; set; }

        private int _orderId = 0;
        private string _consoleInput;

        public void Run()
        {
            Console.WriteLine("This service will simulate the placement  and cancellation of orders.");
            WriteInstructions();

            GetConsoleInput();

            while (_consoleInput != null)
            {
                _consoleInput = _consoleInput.Trim().ToLowerInvariant();
                switch (_consoleInput)
                {
                    case @"p":
                        PlaceOrder();
                        break;
                    case @"c":
                        CancelOrder();
                        break;
                    default:
                        WriteInstructions();
                        break;
                }
                GetConsoleInput();
            }
        }

        private static void WriteInstructions()
        {
            Console.WriteLine();
            Console.WriteLine("Enter 'P' and press 'Enter' to place an order.");
            Console.WriteLine("Enter 'C' and press 'Enter' to cancel an order.");
            Console.WriteLine("Use 'Crtl+C' to exit.");
            Console.WriteLine();
        }

        private void GetConsoleInput()
        {
            _consoleInput = Console.ReadLine();
        }

        private void PlaceOrder()
        {
            var placeOrder = Bus.CreateInstance<PlaceOrder>(m => m.OrderId = ++_orderId);
            Bus.Send(placeOrder);
            Console.WriteLine("Placing order #{0}.", _orderId);
        }

        private void CancelOrder()
        {
            Console.WriteLine("Enter the order # to cancel and press 'Enter'.");
            GetConsoleInput();

            int orderId;
            if (!int.TryParse(_consoleInput, out orderId))
                return;

            Bus.Send<CancelOrder>(order => order.OrderId = orderId);
            Console.WriteLine("Cancelling order #{0}.", _orderId);
        }

        public void Stop()
        {
            
        }
    }
}
