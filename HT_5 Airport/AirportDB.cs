using System.Data.Entity;
using System.Linq;

namespace HT_5_Airport
{
    public class AirportDB : DbContext
    {
       
        public AirportDB()
            : base("name=AirportDB")
        {

        }

     

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Deportation> Deportations { get; set; }
    }

}