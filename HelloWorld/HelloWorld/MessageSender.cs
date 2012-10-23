using Messages;
using NServiceBus;
using log4net;

namespace HelloWorld
{
    public class MessageSender :IWantToRunAtStartup
    {
        public void Run()
        {
            var message = new Request {SaySomething = "Say something"};
            Bus.Send(message);
            LogManager.GetLogger("MessageSender").Info("Sent message");
        }

        public IBus Bus { get; set; }

        public void Stop()
        {
        }
    }
}