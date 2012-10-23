using Messages;
using NServiceBus;
using log4net;

namespace HelloWorldServer
{
    public class RequestHandler: IHandleMessages<Request>
    {
        public void Handle(Request message)
        {
            LogManager.GetLogger("RequestHandler").Info(message.SaySomething);
        }
    }
}