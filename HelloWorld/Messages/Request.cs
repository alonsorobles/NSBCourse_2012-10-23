using NServiceBus;

namespace Messages
{
    public class Request: IMessage
    {
        public string SaySomething { get; set; }
    }
}
