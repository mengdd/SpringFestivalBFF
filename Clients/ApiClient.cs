using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SpringFestivalBFF.Configurations;
using SpringFestivalBFF.Models;

namespace SpringFestivalBFF.Clients
{
    public class ApiClient : IApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SpringFestivalServiceConfiguration _serviceConfiguration;

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public ApiClient(IHttpClientFactory httpClientFactory, IOptions<SpringFestivalServiceConfiguration> options)
        {
            _httpClientFactory = httpClientFactory;
            _serviceConfiguration = options.Value;
        }

        public async Task<List<Show>> GetShowsAsync()
        {
            var url = BuildUrl(_serviceConfiguration.GetShows);
            return await GetModelAsync<List<Show>>(url);
        }

        public Task<Show> CreateShowAsync(Show show)
        {
            throw new NotImplementedException();
        }

        private async Task<TModel> GetModelAsync<TModel>(string url)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <TModel>(responseStream, _jsonSerializerOptions);
        }

        private string BuildUrl(string feature)
        {
            var url = $"{_serviceConfiguration.Uri}/{feature}";
            return url;
        }
    }
}