using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Cars.Kloud.Api.HttpHandlers;

namespace Cars.Kloud.Api.UnitTest.MockHelpers
{
    internal static class MockHttpClientHandlerExtensions
    {
        public static void SetupGetStringAsync(this Mock<IHttpClientHandler> mockHandler, string requestUri, string response, HttpStatusCode statusCode)
        {
            mockHandler.Setup(x=> x.GetAsync(requestUri, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new HttpResponseMessage(statusCode) { Content = new StringContent(response) }));
        }
    }
}
