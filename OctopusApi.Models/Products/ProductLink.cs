using Newtonsoft.Json;

namespace OctopusApi.Products
{
    public class ProductLink
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("rel")]
        public string Rel { get; set; }
    }
}
