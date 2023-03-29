using Gartner.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using System.Text.Json;

namespace Gartner
{
    public class YamlReader
    {
        public YamlReader()
        {
            Console.WriteLine("yaml Reader");
        }
        public void importYamlData(string data,string tableName,string connectionString)
        {
            try
            {
                var r = new StringReader(data);
                var deserializer = new Deserializer();
                var yamlObject = deserializer.Deserialize(r);

                //Yaml to JSON conversion 
                StringWriter sw = new StringWriter();
                var serializer = new Serializer(SerializationOptions.JsonCompatible);
                serializer.Serialize(sw, yamlObject);
                string fileContent = sw.ToString();

                JsonReader jsonReader = new JsonReader();
                jsonReader.importJsonData(fileContent, tableName, connectionString);
        

            }
            catch (Exception)
            {
                Console.WriteLine("Problem converting Json");
                //  return null;
            }
        }
    }
}
