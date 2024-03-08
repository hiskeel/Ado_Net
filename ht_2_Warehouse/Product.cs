using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ht_2_Warehouse
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProducerId { get; set; }
        public int TypeId { get; set; }
        public int Quantity { get; set; }
        public Decimal CostPrice { get; set; }
        public Decimal Price { get; set; }
        public DateTime DeliveryDate {  get; set; }
        public override string ToString()
        {
            return $"Id:{Id,-5} Name:{Name,-15} Type:{TypeId,-15} Quantity:{Quantity,-5} CostPrice:{CostPrice,-5} Producer:{ProducerId,-20} Price:{Price,-12} Delivery Date: {DeliveryDate.Date, -20}";
        }
    }
}
