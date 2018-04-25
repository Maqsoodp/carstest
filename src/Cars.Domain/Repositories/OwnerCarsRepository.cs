using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cars.Domain.Contracts;
using Cars.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Domain.Repositories
{
    public class OwnerCarsRepository : IOwnerCarsRepository
    {
        private readonly CarsDbContext _dbContext;
        public OwnerCarsRepository(CarsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<Owner>> GetOwnerFromDbasync(CancellationToken cancellationToken)
        {
            return await SqlRetryPolicy.BasicPolicy.ExecuteAsync(async () =>
            {
                return await this._dbContext.Owners.Include(x => x.Cars).ToListAsync(cancellationToken);
            });
        }

    }

}
