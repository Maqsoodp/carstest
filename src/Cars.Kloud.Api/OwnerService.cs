using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Cars.Kloud.Api.HttpHandlers;
using Cars.Kloud.Api.Model;
using Cars.Kloud.Api.Utilities;

namespace Cars.Kloud.Api
{
    public class OwnerService : IOwnerService
    {
        private readonly IHttpClientHandler _httpHandler;

        public OwnerService(IHttpClientHandler httpHandler)
        {
            _httpHandler = httpHandler;
        }
        public async Task<List<Owner>> GetOwnerFromUrlAsync(string url, CancellationToken cancellationToken)
        {
            var owners = new List<Owner>();
            using (var response = await this._httpHandler.GetAsync(url, cancellationToken))
            {
                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var stream = await response.Content.ReadAsStreamAsync();
                        owners = stream.CreateFromJsonStream<List<Owner>>();
                    }
                    else
                    {
                        //Generally log error and transient handling also     

                    }
                }
                catch (Exception)
                {
                    //log here and return 
                }
                return owners;
            }
        }
    }
}
