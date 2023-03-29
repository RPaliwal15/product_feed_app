using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gartner
{
    public class FileReader
    {
     
       public bool ImportProducts(string path, string tableName,string ConnectionString)
        {
            try
            {
                using (StreamReader file = new StreamReader(path))
                {
              
                    string fileContent = file.ReadToEnd();
                    FileInfo fi = new FileInfo(path);
                    string extension = fi.Extension;
                    if (extension == ".json")

                    {
                        JsonReader jsonReader = new JsonReader();
                        jsonReader.importJsonData(fileContent, tableName, ConnectionString);
                    }
                    else if (extension == ".yaml")
                    {
                        YamlReader yamlReader = new YamlReader();
                        yamlReader.importYamlData(fileContent,tableName,ConnectionString);
                    }
                    else if (extension == "url")
                    {
                        Console.WriteLine("yet to implement");
                    }
                    return true;
              
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Problem reading file");
                return false;
            }

        }
    }
}
