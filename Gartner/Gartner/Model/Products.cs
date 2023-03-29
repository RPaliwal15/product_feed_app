using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gartner.Model
{
    public class Products
    {
        [JsonProperty("categories")]
       public List<string> Categories { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get;set;}

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
