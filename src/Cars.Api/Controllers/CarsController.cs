using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cars.Kloud.Api;
using Cars.Kloud.Api.Model;

namespace Cars.Api.Controllers
{
    [Route("api/cars")]
    public class CarsController : Controller
    {
        private readonly IOwnerService _ownerService;

        public CarsController(IOwnerService ownerService, ApiConfiguration apiConfig)
        {
            this._ownerService = ownerService;
            ApiConfig = apiConfig;
        }

        private ApiConfiguration ApiConfig { get; }


        /// <summary>
        /// Get all cars available list sorted by car name alphabetically
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List of cars with colors</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var ownersData = await this._ownerService.GetOwnerFromUrlAsync(ApiConfig.Url, cancellationToken);

            var cars = ownersData.Where(a => a.Cars != null)
                .SelectMany(b => b.Cars, (key, value) => new Car
                {
                    Brand = value.Brand,
                    Colour = value.Colour
                })
                ?.Distinct()
                ?.OrderBy(c => c.Brand);

            return Json(cars);
        }

        /// <summary>
        /// Get owners grouped by cars ordered by name and then by color
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List of cars with owners</returns>
        [HttpGet]
        [Route("GetOwnersGroupByCarsOrderedByColorAsync")]
        public async Task<IActionResult> GetOwnersGroupByCarsOrderedByColorAsync(CancellationToken cancellationToken)
        {
            var ownersData = await this._ownerService.GetOwnerFromUrlAsync(ApiConfig.Url, cancellationToken);

            var carsdata = ownersData.Where(x => x.Cars != null)
               .SelectMany(p => p.Cars.Select(c => new { p.Name, c.Brand, c.Colour }))
               .GroupBy(g => g.Brand, d => d, (key, grpData) => new
               {
                   Brand = key,
                   OwnerInfo = grpData.OrderBy(o => o.Name)
                                    .ThenBy(t => t.Colour)
                                    .Select(l => new { l.Name, l.Colour }).ToList()
               })
               .OrderBy(o => o.Brand).ToList();


            return Json(carsdata);
        }

    }
}