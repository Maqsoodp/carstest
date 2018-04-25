using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Cars.Kloud.Api.HttpHandlers
{
    public interface IHttpClientHandler
    {
        Task<HttpResponseMessage> GetAsync(string url, CancellationToken cancellationToken);
    }
}