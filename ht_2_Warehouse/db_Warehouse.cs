using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ht_2_Warehouse
{
    public class db_Warehouse
    {
        SqlConnection connection;
        public db_Warehouse(string connStr) {
            connection = new SqlConnection(connStr);
            connection.Open();
            Console.WriteLine("Connected");
        }

        private void SetParams(ref SqlCommand cmd, Product product)
        {
            cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = product.Name;
            cmd.Parameters.Add("@typeId", System.Data.SqlDbType.Int).Value = product.TypeId;
            cmd.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = product.Quantity;
            cmd.Parameters.Add("@cost_price", System.Data.SqlDbType.Decimal).Value = product.CostPrice;
            cmd.Parameters.Add("@producerId", System.Data.SqlDbType.Int).Value = product.ProducerId;
            cmd.Parameters.Add("@price", System.Data.SqlDbType.Decimal).Value = product.Price;
            cmd.Parameters.Add("@delivDate", System.Data.SqlDbType.Date).Value = product.DeliveryDate;
        }
        private List<Product> getProductsQuery(SqlCommand cmd)
        {
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    TypeId = reader.GetInt32(2),
                    ProducerId = reader.GetInt32(3),
                    Quantity = reader.GetInt32(4),
                    CostPrice = reader.GetDecimal(5),
                    Price = reader.GetDecimal(6),
                    DeliveryDate = reader.GetDateTime(7),


                }) ;
            }
            reader.Close();
            return products;
        }
        public  void InsertType(Types type)
        {
            string cmdText = "insert into [Types] values (@name)";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = type.Name;
            
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows + " row affected.");
        }
        public void InsertProducer(Producers producer)
        {
            string cmdText = "insert into Producers values (@name)";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = producer.Name;

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows + " row affected.");
        }
        public void InsertProduct(Product product)
        {
            string cmdText = "insert into Products values (@name,@typeId, @producerId,@quantity,@cost_price,@price,@delivDate)";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            SetParams(ref cmd, product);
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows + " row affected.");
        }
        public List<Product> GetProducts()
        {
            string cmdText = "select * from Products";
            SqlCommand cmd = new SqlCommand(cmdText,connection);

            return getProductsQuery(cmd);
        }
        public void UpdateProduct(Product product)
        {

        }

    }
}
