namespace SignalRWebApp.Tests
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class Test
    {
        [Test]
        public async Task SignalR_OnConnect_ShouldReturn3Messages()
        {
            // arrange
            Mock<IHubCallerClients> mockClients = new Mock<IHubCallerClients>();
            Mock<IClientProxy> mockClientProxy = new Mock<IClientProxy>();

            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);


            SimpleHub simpleHub = new SimpleHub()
            {
                Clients = mockClients.Object
            };

            // act
            await simpleHub.Welcome();


            // assert
            mockClients.Verify(clients => clients.All, Times.Once);

            mockClientProxy.Verify(
                clientProxy => clientProxy.SendCoreAsync(
                    "welcome",
                    It.Is<object[]>(o => o != null && o.Length == 1 && ((object[])o[0]).Length == 3),
                    default(CancellationToken)),
                Times.Once);
        }
    }
}