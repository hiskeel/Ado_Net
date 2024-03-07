using _3_Data_acces_Layer;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml;


internal class Program
{
    
    public class SportShop_db
    {
        //Create

        //read
        // update
        //Delete
        SqlConnection connection;
        public SportShop_db(string connStr) { 
            connection = new SqlConnection(connStr);
            connection.Open();
            Console.WriteLine("Connected");
        }
        private void SetParams(ref SqlCommand cmd, Product product)
        {
            cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = product.Name;
            cmd.Parameters.Add("@type", System.Data.SqlDbType.NVarChar).Value = product.Type;
            cmd.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = product.Quantity;
            cmd.Parameters.Add("@cost_price", System.Data.SqlDbType.Int).Value = product.CostPrice;
            cmd.Parameters.Add("@producer", System.Data.SqlDbType.NVarChar).Value = product.Producer;
            cmd.Parameters.Add("@price", System.Data.SqlDbType.Int).Value = product.Price;
        }
        public void Create(Product product)
        {
            
            string cmdText = "insert into Products values (@name,@type,@quantity,@cost_price,@producer,@price)";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            SetParams(ref cmd, product);
            cmd.ExecuteNonQuery();
            Console.WriteLine("1 row affected.");
        }
        private List<Product> getProductsQuery(SqlCommand cmd)
        {
            var reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Type = reader.GetString(2),
                    Quantity = reader.GetInt32(3),
                    CostPrice = reader.GetInt32(4),
                    Producer = reader.GetString(5),
                    Price = reader.GetInt32(6)

                });
            }
            reader.Close();
            return products;
        }
        public Product GetOneProduct(int id)
        {
            string cmdText = "select * from Products where Id = @id";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            return getProductsQuery(cmd).FirstOrDefault();
        }
        public void Update(Product product) 
        {
            string cmdText = @"update Products
                           set
                                Name = @name,
                                TypeProduct = @type,
                                Quantity = @quantity,
                                CostPrice = @cost_price,
                                Producer = @producer,
                                Price = @price
                            where Id = @id";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            SetParams(ref cmd, product);
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = product.Id;
            cmd.ExecuteNonQuery();

        }
        public void Delete() 
        { 
            
        }
        public List<Product> GetAllProducts() {

            string cmdText = "select * from Products";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
           
            return getProductsQuery(cmd);
        }
    }
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        SportShop_db db = new SportShop_db(ConfigurationManager.ConnectionStrings["connSportShop"].ConnectionString);
        foreach (var item in db.GetAllProducts()) {
            Console.WriteLine(item);
        }
        //db.Create(new Product()
        //{
        //    Name = "Мишка",
        //    Type = "Аксесуари",
        //    Quantity = 15,
        //    CostPrice = 600,
        //    Producer = "Bloody",
        //    Price = 900
        //});
        //foreach (var item in db.GetAllProducts())
        //{
        //    Console.WriteLine(item);
        //}

        Product product = db.GetOneProduct(1);
        Console.WriteLine("\n" + product);
        product.Price -= 50;
        product.Quantity -= 2;
        db.Update(product);
        Console.WriteLine("\n" + product);
    }
}