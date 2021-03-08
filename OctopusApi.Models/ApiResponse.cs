using Newtonsoft.Json;
using System.Collections.Generic;

namespace OctopusApi
{
    public class ApiResponse<TResult>
        where TResult : class
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("results")]
        public TResult[] Results { get; set; }
    }
}
