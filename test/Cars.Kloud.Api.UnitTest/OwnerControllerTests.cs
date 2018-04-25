using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Cars.Kloud.Api.Model;
using Cars.Kloud.Api.HttpHandlers;
using Cars.Kloud.Api.UnitTest.MockHelpers;

namespace Cars.Kloud.Api.UnitTest
{
    //System Under Test
    [TestFixture]
    public class OwnerControllerTests
    {
        //Method under test
        [TestFixture]
        public class GetOwnerFromUrlAsyncMethod
        {
            [Test]
            public async Task WhenEmptyResponse_GivesEmptyResult()
            {
                // Arrange
                var requestUri = string.Empty;
                Owner expectedResponse = null;
                var mockHandler = new Mock<IHttpClientHandler>();
                mockHandler.SetupGetStringAsync(requestUri, "",HttpStatusCode.OK);
                var ownerService = new OwnerService(mockHandler.Object);
                // Act
                var result = await ownerService.GetOwnerFromUrlAsync(requestUri, CancellationToken.None);
                
                // Assert
                Assert.AreEqual(expectedResponse, result);

            }
        }
    }
}
