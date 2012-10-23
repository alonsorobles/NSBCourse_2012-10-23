using StructureMap.Configuration.DSL;

namespace HelloWorldServer
{
    public class HelloWorldServerRegistry: Registry
    {
        public HelloWorldServerRegistry()
        {
            For<ISaySomething>().Singleton();
        }
    }
}