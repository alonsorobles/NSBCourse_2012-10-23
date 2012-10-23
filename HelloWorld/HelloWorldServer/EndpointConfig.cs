using NServiceBus;

namespace HelloWorldServer
{
    public class EndpointConfig: IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With()
                .DefaultBuilder()
                .XmlSerializer("http://acme.com");
        }
    }
}
