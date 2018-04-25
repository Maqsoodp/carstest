using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Cars.Api;
using Cars.Kloud.Api;
using Cars.Api.Controllers;
using Cars.Kloud.Api.Model;
using System.Linq;
using Cars.Domain.Contracts;
using Newtonsoft.Json;

namespace Cars.Api.UnitTest
{
    [TestFixture]
    public class OwnersControllerTest
    {

        [TestFixture]
        public class GetExternalAsync
        {
            /// <summary>
            /// Test Cars Api using Kloud API Call
            /// </summary>
            /// <returns></returns>
            [Test]
            public async Task WhenValidApi_ReturnsOwnersList_FromApiAsync()
            {
                // Arrange
                var expected = ApiTestData.GetTestOwnerData();
                var mockOwnerService = new Mock<IOwnerService>();
                var mockOwnerCarsRepository = new Mock<IOwnerCarsRepository>();

                mockOwnerService.Setup(ownerService =>
                        ownerService.GetOwnerFromUrlAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(expected));

                var controller = new OwnersController(mockOwnerService.Object, mockOwnerCarsRepository.Object, new ApiConfiguration());

                // Act
                var actionResult = await controller.GetExternalAsync(CancellationToken.None);

                // Assert
                Assert.NotNull(actionResult);

                var result = actionResult as JsonResult;

                Assert.NotNull(result);
                var actual = result.Value as IEnumerable<Kloud.Api.Model.Owner>;

                var expectedCarCount = expected.Where(x => x.Cars != null).SelectMany(x => x.Cars).Count();
                var actualCarCount = actual.Where(x => x.Cars != null).SelectMany(x => x.Cars).Count();

                Assert.AreEqual(expectedCarCount, actualCarCount);

                Assert.AreEqual(expected.Count(), actual.Count());
            }


        }

        [TestFixture]
        public class GetInternalAsync
        {
            /// <summary>
            /// Test Owners Api using tabase call
            /// </summary>
            /// <returns></returns>
            [Test]
            public async Task WhenValidApi_ReturnsOwnersList_FromDbAsync()
            {
                // Arrange
                var expected = DatabaseTestData.GetTestOwnerData();
                var mockOwnerService = new Mock<IOwnerService>();
                var mockOwnerCarsRepository = new Mock<IOwnerCarsRepository>(MockBehavior.Loose);

                mockOwnerCarsRepository.Setup(ownerCarsRepository =>
                        ownerCarsRepository.GetOwnerFromDbasync(It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(expected));


                var controller = new OwnersController(mockOwnerService.Object, mockOwnerCarsRepository.Object, new ApiConfiguration());

                // Act
                var actionResult = await controller.GetInternalAsync(CancellationToken.None);

                // Assert
                var result = actionResult as JsonResult;
                Assert.NotNull(result);

                var actual = result.Value as IEnumerable<Domain.Models.Owner>;

                var expectedCarCount = expected.Where(x => x.Cars != null).SelectMany(x => x.Cars).Count();
                var actualCarCount = actual.Where(x => x.Cars != null).SelectMany(x => x.Cars).Count();

                Assert.AreEqual(expectedCarCount, actualCarCount);

                Assert.AreEqual(expected.Count(), actual.Count());

            }


        }
    }
}