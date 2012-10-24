using NServiceBus;

namespace Messages
{
    public class Query : IMessage
    {
        public int NumberOfResponses { get; set; }
    }

    public class QueryResult : IMessage
    {
        public string Something { get; set; } 
    }
}