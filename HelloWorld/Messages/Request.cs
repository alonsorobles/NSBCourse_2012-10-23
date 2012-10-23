using NServiceBus;

namespace Messages
{
    [TimeToBeReceived("00:01:00")]
    public class Request: IMessage
    {
        public string SaySomething { get; set; }
    }
}
