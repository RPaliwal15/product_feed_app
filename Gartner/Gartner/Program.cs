

using Gartner;
using Microsoft.Extensions.Configuration;


var builder = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json");

var configuration = builder.Build();
string ConnectionString = configuration.GetSection("ConnectionString").Value;


if (args.Length == 3 && args[0] == "import")
{
    string tableName = args[1];
    string path = args[2];
    //  string tableName = "capterra";
    //Either pass path as argument or replace this with file path.
    //string path = @"C:\Users\Rahul\Desktop\Gartner\software engineer\coding\feed-products\softwareadvice.json"; 
    FileReader fileReader = new FileReader();
    fileReader.ImportProducts(path, tableName, ConnectionString);
}
else
{
    Console.WriteLine("Invalid Command.");
}


