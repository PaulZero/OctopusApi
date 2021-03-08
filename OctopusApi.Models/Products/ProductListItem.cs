using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopusApi.Products
{
    public class ProductListItem
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is_variable")]
        public bool IsVariable { get; set; }

        [JsonProperty("is_green")]
        public bool IsGreen { get; set; }

        [JsonProperty("is_prepay")]
        public bool IsPrepay { get; set; }

        [JsonProperty("is_business")]
        public bool IsBusiness { get; set; }

        [JsonProperty("is_restricted")]
        public bool IsRestricted { get; set; }

        [JsonProperty("term")]
        public int? Term { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("available_from")]
        public DateTime AvailableFrom { get; set; }

        [JsonProperty("available_to")]
        public DateTime? AvailableTo { get; set; }

        [JsonProperty("links")]
        public ProductLink[] Links { get; set; }
    }
}
