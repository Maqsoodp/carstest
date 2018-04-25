using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cars.Kloud.Api.Model;

namespace Cars.Kloud.Api
{
    public interface IOwnerService
    {
        Task<List<Owner>> GetOwnerFromUrlAsync(string url, CancellationToken cancellationToken);
    }
}
