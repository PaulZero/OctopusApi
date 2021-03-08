using Newtonsoft.Json;
using OctopusApi.Accounts;
using OctopusApi.Client.Responses;
using OctopusApi.Consumption;
using OctopusApi.Enums;
using OctopusApi.Products;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OctopusApi.Client
{
    public class OctopusApiClient
    {
        private const string DefaultBaseUri = "https://api.octopus.energy";

        private readonly EnergyAccount _account;
        private readonly string _baseUri;
        private readonly HttpClient _httpClient;

        public OctopusApiClient(EnergyAccount account, HttpClient httpClient = null, string baseUri = DefaultBaseUri)
        {
            _account = account;
            _baseUri = baseUri ?? DefaultBaseUri;
            _httpClient = httpClient ?? new HttpClient();

            ConfigureHttpClient();
        }

        private void ConfigureHttpClient()
        {
            var rawAuthString = $"{_account.ApiKey}:";
            var base64AuthString = Convert.ToBase64String(Encoding.UTF8.GetBytes(rawAuthString));

            _httpClient.BaseAddress = new Uri(_baseUri);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64AuthString);
        }

        public async Task<string> GetIndustryStuff(string postcode = null)
        {
            var uri = postcode == null
                ? "/v1/industry/grid-supply-points/"
                : $"/v1/industry/grid-supply-points/?post_code={postcode}";

            return await _httpClient.GetStringAsync(uri);
        }

        public async Task<GetConsumptionResult> GetConsumptionAsync(EnergyMeter meter)
        {
            var uri = (meter.Type == EnergyType.Electricity)
                ? $"/v1/electricity-meter-points/{meter.Identifier}/meters/{meter.SerialNumber}/consumption/"
                : $"/v1/gas-meter-points/{meter.Identifier}/meters/{meter.SerialNumber}/consumption/";
            
            var json = await _httpClient.GetStringAsync(uri);            
            var response = JsonConvert.DeserializeObject<ApiResponse<ConsumptionItem>>(json);

            return new GetConsumptionResult
            {
                Unit = meter.Type == EnergyType.Electricity ? ConsumptionUnit.KilowattHour : ConsumptionUnit.CubicMetres,
                Items = response.Results ?? Array.Empty<ConsumptionItem>()
            };
        }

        public async Task<ListProductsResult> ListProductsAsync()
        {
            var products = new List<ProductListItem>();
            var nextUrl = default(string);

            do
            { 
                var json = await _httpClient.GetStringAsync(nextUrl ?? "/v1/products/");
                var response = JsonConvert.DeserializeObject<ApiResponse<ProductListItem>>(json);

                products.AddRange(response.Results);

                nextUrl = response.Next;

                if (nextUrl != null)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            }
            while (nextUrl != null);

            return new ListProductsResult
            {
                Products = products.ToArray()
            };
        }
    }
}
