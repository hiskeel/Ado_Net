using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_DB_first
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            SportShopContext context = new SportShopContext();

            //var query = context.Products.Select(p => p);
            //var query = context.Products.Where(p =>p.Price >300).OrderBy(or => or.Name);
            //foreach (var product in query) {
            //    Console.WriteLine($"Product: {product.Name,15}, Price: {product.Price,10}, Producer: {product.Producer}");
            //}

            //context.Products.Add(new Product
            //{
            //    Name = "Lime",
            //    TypeProduct = "Fruct",
            //    CostPrice = 20,
            //    Price = 35,
            //    Producer = "Mexico",
            //    Quantity = 100
            //}) ;
            //context.SaveChanges();
            //var query = context.Products.Where(p => p.Price > 300).OrderBy(or => or.Name);
            //foreach (var product in query)
            //{
            //    Console.WriteLine($"Product: {product.Name,15}, Price: {product.Price,10}, Producer: {product.Producer}");
            //}

            int id = 4;
            //Product product = context.Products.FirstOrDefault(p => p.Id == id);
            //Product product = context.Products.Find(id);
            //product.Price = (int)(product.Price * 1.1);
            //context.SaveChanges();

            //Product product = context.Products.Find(8);
            //context.Products.Remove(product);
            //context.SaveChanges();

            foreach (var p  in context.Salles.Include(nameof(Salle.Product)).Where(p => p.Product !=null ))
                {
                Console.WriteLine( $"{p.Price,10}, {p.Quantity, 7}, {p.Product.Name}, {p.Client.FullName}");
            }
        }
    }
}
