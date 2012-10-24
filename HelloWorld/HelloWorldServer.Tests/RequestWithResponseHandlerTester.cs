using Messages;
using NServiceBus.Testing;
using NUnit.Framework;

namespace HelloWorldServer.Tests
{
    [TestFixture]
    public class RequestWithResponseHandlerTester
    {
        [Test]
// ReSharper disable InconsistentNaming
        public void Should_return_0()
// ReSharper restore InconsistentNaming
        {
            Test.Initialize();

            Test.Handler<RequestWithResponseHandler>()
                .ExpectReturn<int>(i => i == 0)
                .OnMessage<RequestWithResponse>(m => m.SaySomething = "");
        }
    }
}