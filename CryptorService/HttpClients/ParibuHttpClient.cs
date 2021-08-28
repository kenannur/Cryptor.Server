using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CryptorService.Models;
using Vegas.NetCore.Common.Extensions;

namespace CryptorService.HttpClients
{
    public interface IParibuHttpClient
    {
        Task<TInnerResponse> FetchAsync<TInnerResponse>(string requestUri, CancellationToken cancellationToken = default);
    }

    public class ParibuHttpClient : IParibuHttpClient
    {
        private readonly HttpClient _httpClient;

        public ParibuHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://v3.paribu.com");
        }

        public async Task<TInnerResponse> FetchAsync<TInnerResponse>(string requestUri, CancellationToken cancellationToken = default)
        {
            var fullRequestUri = $"/app/{requestUri}";
            var jResponse = await _httpClient.GetStringAsync(fullRequestUri);

            var paribuApiResponse = jResponse.ToObject<ParibuApiResponse<TInnerResponse>>();
            if (paribuApiResponse is not null && paribuApiResponse.Success)
            {
                return paribuApiResponse.Data;
            }
            throw new Exception("Invalid response");
        }
    }
}
