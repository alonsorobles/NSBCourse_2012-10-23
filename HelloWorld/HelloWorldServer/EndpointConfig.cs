using NServiceBus;

namespace HelloWorldServer
{
    public class EndpointConfig: IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization, ISpecifyMessageHandlerOrdering
    {
        public void Init()
        {
            Configure.With()
                .DefaultBuilder()
                .XmlSerializer("http://acme.com");
        }

        public void SpecifyOrder(Order order)
        {
            order.SpecifyFirst<Auth>();
        }
    }
}
