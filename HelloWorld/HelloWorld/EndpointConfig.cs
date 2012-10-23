using NServiceBus;

namespace HelloWorld
{
    public class EndpointConfig: IConfigureThisEndpoint, AsA_Client, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With()
                .DefaultBuilder()
                .XmlSerializer("http://acme.com");
        }
    }
}
