using OctopusApi.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopusApi.Client.Responses
{
    public class ListProductsResult
    {
        public ProductListItem[] Products { get; set; }
    }
}
