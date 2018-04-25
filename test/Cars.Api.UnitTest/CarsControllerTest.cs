using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using Cars.Api;
using Cars.Kloud.Api;
using Cars.Api.Controllers;
using Cars.Kloud.Api.Model;

namespace Cars.Api.UnitTest
{
    [TestFixture]
    public class CarsControllerTest
    {
       
        [TestFixture]
        public class GetAsync
        {

            /// <summary>
            /// Test Cars Api using Kloud API Call
            /// </summary>
            /// <returns></returns>
            [Test]
            public async Task WhenValidApi_ReturnsCars()
            {
                // Arrange
                var expected = ApiTestData.GetTestOwnerData();
                var mockOwnerService = new Mock<IOwnerService>();
                mockOwnerService.Setup(ownerService =>
                        ownerService.GetOwnerFromUrlAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(expected));

                var controller = new CarsController(mockOwnerService.Object, new ApiConfiguration());

                // Act
                var actionResult = await controller.GetAsync(CancellationToken.None);

                // Assert
                Assert.NotNull(actionResult);

                var result = actionResult as JsonResult;

                Assert.NotNull(result);
                var actual = result.Value as IEnumerable<Car>;

                Debug.Assert(actual != null, nameof(actual) + " != null");
                var expectedCount = expected.Where(x => x.Cars != null).SelectMany(x => x.Cars).Count();
                Assert.AreEqual(expectedCount, actual.Count());
            }
        }


        [TestFixture]
        public class GetOwnersGroupByCarsOrderedByColorAsync
        {
            /// <summary>
            /// Test Cars Api using Kloud API Call
            /// </summary>
            /// <returns></returns>
            [Test]
            public async Task WhenRequested_Returns_GetOwnersGroupByCarsOrderedByColorAsync()
            {
                // Arrange
                var expectedEntities = ApiTestData.GetTestOwnerData();


                var mockOwnerService = new Mock<IOwnerService>();
                mockOwnerService.Setup(ownerService =>
                        ownerService.GetOwnerFromUrlAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(expectedEntities));

                var controller = new CarsController(mockOwnerService.Object, new ApiConfiguration());

                // Act
                var actionResult = await controller.GetOwnersGroupByCarsOrderedByColorAsync(CancellationToken.None);

                // Assert
                var result = actionResult as JsonResult;
                Assert.NotNull(result);

                var definition = new[]
                {
                    new
                    {
                        Brand = "",
                        OwnerInfo = new[] {new { Name= "", Colour = ""}}
                    }
                };

                var resultJson = JsonConvert.SerializeObject(result.Value);
                var ownerList = JsonConvert.DeserializeAnonymousType(resultJson, definition);

                Assert.AreEqual(ownerList.Count(), 4);
                Assert.AreEqual(ownerList.ElementAt(0).Brand, "Audi");
                Assert.AreEqual(ownerList.ElementAt(ownerList.Count() - 1).Brand, "Toyota");
                Assert.AreEqual(ownerList.ElementAt(0).OwnerInfo.Count(), 1);
                Assert.AreEqual(ownerList.Where(x => x.Brand.Equals("Mercedes", StringComparison.OrdinalIgnoreCase))?.FirstOrDefault().OwnerInfo.Count(), 1);

            }


        }
    }
}