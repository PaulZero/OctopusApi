using Newtonsoft.Json;
using System;

namespace OctopusApi.Consumption
{
    public class ConsumptionItem
    {
        [JsonProperty("consumption")]
        public double Consumption { get; set; }

        [JsonProperty("interval_start")]
        public DateTime IntervalStart { get; set; }

        [JsonProperty("interval_end")]
        public DateTime IntervalEnd { get; set; }
    }
}
