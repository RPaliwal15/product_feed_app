using Gartner;
using Gartner.DataRepository;
using MySql.Data.MySqlClient;
using Xunit;

namespace GartnerTest
{
    public class DbConnetorTest
    {
        [Fact]
        public void IsTableExisitReturnFalse()
        {
            DBConnector dBConnector = new DBConnector();
            string connStr = "server=localhost;user=root;database=gartner;port=3306;password=12345";
            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();
            var result =  DBConnector.IsTableExistInDb("abc", conn);
            conn.Close();

            //Assert  
            Assert.Equal(false, result);
        }

        [Fact]
        public void ShouldInsertRow()
        {
            string connStr = "server=localhost;user=root;database=gartner;port=3306;password=12345";
            string command = "insert into softwareadvice(categories,twitter,title) VALUES ('abc Service,Call Center','@example','test')";
            MySqlConnection conn = new MySqlConnection(connStr);
            var result =  DBConnector.Insert(command,conn);

            Assert.Equal(true, result);
        }

        [Fact]
        public void ShouldReturnFalseInvalidFile()
        {
            string connStr = "test";
            string path = "";
            string tableName = "softwareadvice";
            FileReader fileReader = new FileReader();
            var result = fileReader.ImportProducts(path, tableName,connStr);
            Assert.Equal(false, result);
        }

    }
}