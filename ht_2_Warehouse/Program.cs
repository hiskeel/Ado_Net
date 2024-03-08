
using ht_2_Warehouse;
using System.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        db_Warehouse db = new db_Warehouse(ConfigurationManager.ConnectionStrings["connWarehouse"].ConnectionString);
        //db.InsertType(new Types() { Name = "Electronic" });

        //db.InsertProducer(new Producers() { Name = "LG" });

        //db.InsertProduct(new Product
        //{
        //    Name = "TV",
        //    TypeId = 6,
        //    ProducerId = 6,
        //    Quantity = 7,
        //    CostPrice = 5000,
        //    Price = 11000,
        //    DeliveryDate = new DateTime(2024,1,21)

        //});
        foreach (var item in db.GetProducts())
        {
            Console.WriteLine(item);
        }

    }
}