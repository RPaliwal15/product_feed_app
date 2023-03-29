using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gartner.Model
{
    public class CapterraProduct
    {
       
        public string tags { get; set; }

        public string name { get; set; }

        public string twitter { get; set; }
    }

    public class CapterraProductList
    {
        public List<CapterraProduct> capterraProducts { get; set; }
    }
}
