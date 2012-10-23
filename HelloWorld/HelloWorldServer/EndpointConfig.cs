using NServiceBus;

namespace HelloWorldServer
{
    public class EndpointConfig: IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization, ISpecifyMessageHandlerOrdering
    {
        public void Init()
        {
            Configure.With()
                .StructureMapBuilder(StructureMapConfig.Container)
                .XmlSerializer("http://acme.com")
                .RijndaelEncryptionService();
        }

        public void SpecifyOrder(Order order)
        {
            order.SpecifyFirst<Auth>();
        }
    }
}
