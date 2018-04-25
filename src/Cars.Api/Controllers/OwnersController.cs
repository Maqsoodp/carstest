using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cars.Kloud.Api;
using Cars.Domain.Contracts;
using Cars.Domain.Models;

namespace Cars.Api.Controllers
{
    [Route("api/owners")]
    public class OwnersController : Controller
    {
        private readonly IOwnerService _ownerService;
        private readonly IOwnerCarsRepository _ownerCarsRepository;
        private ApiConfiguration ApiConfig { get; }

        public OwnersController(IOwnerService ownerService, IOwnerCarsRepository ownerCarsRepository, ApiConfiguration apiConfig)
        {
            this._ownerService = ownerService;
            this._ownerCarsRepository = ownerCarsRepository;
            ApiConfig = apiConfig;
        }

        /// <summary>
        /// Get owners list with cars from the external source 
        /// https://kloudcodingtest.azurewebsites.net/api/cars
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>owners with cars</returns>
        [HttpGet]
        [Route("external")]
        public async Task<IActionResult> GetExternalAsync(CancellationToken cancellationToken)
        {
            var ownersData = await this._ownerService.GetOwnerFromUrlAsync(this.ApiConfig.Url, cancellationToken);
            return Json(ownersData);

        }


        /// <summary>
        /// Get owners list with cars from in memory database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>owners with cars</returns>
        [HttpGet]
        [Route("internal")]
        public async Task<IActionResult> GetInternalAsync(CancellationToken cancellationToken)
        {
            var ownersData = await this._ownerCarsRepository.GetOwnerFromDbasync(cancellationToken);
            var result = ownersData.Select(o => new Owner
            {
                Name = o.Name,
                Cars = o.Cars?.Select(c => new Car
                {
                    Brand = c.Brand,
                    Colour = c.Colour
                }).ToList()
            });
            return Json(result);

        }
    }
}