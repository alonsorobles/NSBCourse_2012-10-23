using System;
using System.Threading;
using NServiceBus;
using Sales.Messages.Events;

namespace Sales
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher
    {
    }
}
