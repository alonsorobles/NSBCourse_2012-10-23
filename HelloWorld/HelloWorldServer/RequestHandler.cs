using Messages;
using NServiceBus;
using log4net;

namespace HelloWorldServer
{
    public class RequestHandler: IHandleMessages<Request>
    {
        private readonly ISaySomething _saySomething;

        public RequestHandler(ISaySomething saySomething)
        {
            _saySomething = saySomething;
        }

        public void Handle(Request message)
        {
            LogManager.GetLogger("RequestHandler").Info(message.SaySomething);
            LogManager.GetLogger("RequestHandler").Info(_saySomething.InResponseTo(message.SaySomething));
        }
    }
}