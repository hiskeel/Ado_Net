using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _2_Params.Program;

namespace _2_Params
{
    internal class Program
    {
        public class Product
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public int Quantity { get; set; }
            public int CostPrice { get; set; }
            
            public string Producer { get; set; }
            public int Price {  get; set; }


        }
        static void Main(string[] args)
        {
            
            string conn = ConfigurationManager.ConnectionStrings["connSportShop"].ConnectionString;
            
            
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            AddProduct(new Product() { Name = "Шарф", Type = "Аксесуари", Quantity = 5, CostPrice = 600, Producer = "Україна", Price = 500 }, connection);
            
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            string name = Console.ReadLine();
            //ShowProductByName(name, connection);
           


        }

        private static void AddProduct(Product product, SqlConnection connection)
        {
            string cmdText = "insert into Products values (@name,@type,@quantity,@cost_price,@producer,@price)";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.Add("@name",System.Data.SqlDbType.NVarChar).Value = product.Name;
            cmd.Parameters.Add("@type", System.Data.SqlDbType.NVarChar).Value = product.Type;
            cmd.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = product.Quantity;
            cmd.Parameters.Add("@cost_price", System.Data.SqlDbType.Int).Value = product.CostPrice;
            cmd.Parameters.Add("@producer", System.Data.SqlDbType.NVarChar).Value = product.Producer;
            cmd.Parameters.Add("@price", System.Data.SqlDbType.Int).Value = product.Price;
            cmd.ExecuteNonQuery();
        }

        private static void ShowProductByName(string name, SqlConnection conn )
        {
            
            string cmdText = $"select * from Products where Name = '{name}'";

            SqlCommand cmd = new SqlCommand(cmdText, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            ShowProducts(reader);

        }

        private static void ShowProducts(SqlDataReader reader)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"{reader.GetName(i),16}");
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 120));
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader[i],16}");

                }
                Console.WriteLine();
            }
        }
    }
}
