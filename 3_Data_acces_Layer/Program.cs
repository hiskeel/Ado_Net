using System.Configuration;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml;


internal partial class Program
{
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

        //Product product = db.GetOneProduct(1);
        //Console.WriteLine("\n" + product);
        //product.Price -= 50;
        //product.Quantity -= 2;
        //db.Update(product);
        //Console.WriteLine("\n" + product);
    }
}