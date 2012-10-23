using System;
using System.Threading;
using StructureMap;

namespace HelloWorldServer
{
    public class StructureMapConfig
    {
        private static readonly Lazy<IContainer> LazyContainer =
            new Lazy<IContainer>(BuildContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        private static IContainer BuildContainer()
        {
            return new Container(config => config.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.LookForRegistries();
                }));
        }

        public static IContainer Container
        {
            get { return LazyContainer.Value; }
        }
    }
}