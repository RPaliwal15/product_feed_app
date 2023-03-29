using Gartner.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Gartner.DataRepository
{
    public class DBConnector 
    {

        public void DbAccess(dynamic productList, string tableName,string connStr)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                saveTableToDataBase(tableName, conn, productList);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            conn.Close();
            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }

        private void saveTableToDataBase(string tableName, MySqlConnection con, dynamic productList)
        {

            // check if table exist in sql server db
            if (IsTableExistInDb(tableName, con) == true)
            {
                Console.WriteLine("---- Import Start ---");
                if (tableName == "softwareadvice")
                {
                    AddSoftwareAdviceData(productList,con);
                }
                else
                {
                    AddCapetraData(productList, con);
                }
                Console.WriteLine("---- Import Completed ---");
            }
            else
            {
                // create table, replace with your column names and data types
                Console.WriteLine("table not Exsit");
            }
        }

        public static Boolean IsTableExistInDb(string tableName, MySqlConnection con)
        {

            Object result = ExecuteScalarWithAnonimusType("SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = " + "'" + tableName + "'", con);

            if (result != null && byte.Parse(result.ToString()) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddCapetraData(List<CapterraProduct> productList, MySqlConnection con)
        {
            foreach (CapterraProduct product in productList)
            {
                string Tags = String.IsNullOrEmpty(product?.tags) ? null : product?.tags.ToString();
                string Name = String.IsNullOrEmpty(product?.name) ? null : product?.name.ToString(); 
                string Twitter = String.IsNullOrEmpty(product?.twitter) ? null : product?.twitter.ToString();
                Console.WriteLine("importing: Tags :{0}; Name : {1} ; Twitter : {2} ", Tags, Name, Twitter);
                string command = string.Format("insert into capterra(tags,name,twitter) VALUES ('{0}','{1}','{2}')", Tags, Name, Twitter);
                Insert(command, con);
            }
        }
        public void  AddSoftwareAdviceData(ProductsList productList, MySqlConnection con)
        {
            foreach (Products product in productList.products)
            {
                string categories = product?.Categories.Count > 0 ? string.Join(",", product.Categories) : null;
                string Title = String.IsNullOrEmpty(product?.Title) ? null : product?.Title.ToString(); ;
                string Twitter = String.IsNullOrEmpty(product?.Twitter) ? null : product?.Twitter.ToString();
                Console.WriteLine("importing: Name :{0}; Categories : {1} ; Twitter : {2} ", Title, categories, Twitter);
                string command = string.Format("insert into softwareadvice(categories,twitter,title) VALUES ('{0}','{1}','{2}')", categories, Twitter, Title);
                Insert(command, con);
            }
            
        }
        public static object ExecuteScalarWithAnonimusType(string command, MySqlConnection con)
        {
            MySqlCommand cmd = new MySqlCommand(command, con);
            try
            {
                return cmd.ExecuteScalar();
            }

            catch (Exception ex)
            {
                return null;
            }
            finally
            {

                con.Close();
            }
        }

        public static bool Insert(string command, MySqlConnection con)
        {
            try
            {

                con.Open();
                MySqlCommand cmd = new MySqlCommand(command, con);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }


    }


}
