using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cars.Domain.Models;

namespace Cars.Domain.Contracts
{
    public interface IOwnerCarsRepository
    {
        Task<List<Owner>> GetOwnerFromDbasync(CancellationToken cancellationToken);
    }
}
