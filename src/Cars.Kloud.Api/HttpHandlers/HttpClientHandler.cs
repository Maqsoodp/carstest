using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Cars.Kloud.Api.Utilities;
using Polly;
using Polly.Retry;
using Polly.Wrap;

namespace Cars.Kloud.Api.HttpHandlers
{
    public class HttpClientHandler : IHttpClientHandler
    {
        private readonly HttpClient _client;
        private const int DefaultRetryCount = 3;
        private static readonly TimeSpan DefaultRetryTimeout = TimeSpan.FromSeconds(5);

        public HttpClientHandler()
        {
            this._client = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetAsync(string url, CancellationToken cancellationToken)
        {
            Ensure.IsUrl(url, "url");

            var basicRetryPolicy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(DefaultRetryCount, retryAttempt => DefaultRetryTimeout);

            var response = await basicRetryPolicy.ExecuteAsync(() => _client.GetAsync(url, cancellationToken));

            return response;
        }
    }
}