using NServiceBus;
using log4net;

namespace HelloWorld
{
    public class Class1: IConfigureThisEndpoint, AsA_Client, IWantCustomLogging
    {
        public void Init()
        {
            SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);
        }
    }
}
