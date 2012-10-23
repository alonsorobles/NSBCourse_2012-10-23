using NServiceBus;
using log4net;

namespace HelloWorld
{
    public class Class1: IConfigureThisEndpoint, IWantToRunAtStartup
    {
        public void Run()
        {
            LogManager.GetLogger("Class1").Info("Hello World!");
        }

        public void Stop()
        {
            
        }
    }
}
