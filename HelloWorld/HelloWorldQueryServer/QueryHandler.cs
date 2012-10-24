using Messages;
using NServiceBus;

namespace HelloWorldQueryServer
{
    public class QueryHandler : IHandleMessages<Query>
    {
        public void Handle(Query message)
        {
            for (var i = 0; i < message.NumberOfResponses; i++)
            {
                var something = i;
                Bus.Reply<QueryResult>(m => m.Something = something.ToString());
            }
        }

        public IBus Bus { get; set; }
    }
}