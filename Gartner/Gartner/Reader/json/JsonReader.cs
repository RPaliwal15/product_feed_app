using Gartner.DataRepository;
using Gartner.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gartner
{
    public class JsonReader
    {
   
        public void importJsonData(string data,string tableName,string ConnectionString)
        {
            try
            {
                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                if(tableName == "softwareadvice")
                {
                    var response = JsonConvert.DeserializeObject<ProductsList>(data, serializerSettings);
                    DBConnector dBConnector = new DBConnector();
                    dBConnector.DbAccess(response, tableName, ConnectionString);
                }
                else
                {
                    var response = JsonConvert.DeserializeObject<List<CapterraProduct>>(data, serializerSettings);
                    DBConnector dBConnector = new DBConnector();
                    dBConnector.DbAccess(response, tableName, ConnectionString);

                }
              
            }
            catch (Exception)
            {
                Console.WriteLine("Problem converting Json");
              
            }
        }
    }
}
