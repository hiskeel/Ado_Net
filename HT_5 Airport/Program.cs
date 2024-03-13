using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HT_5_Airport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirportDB context = new AirportDB();

            context.Planes.Add(new Plane
            {
                MaxPassengers = 70,
                Model = "Boing",
                Country = "USA",
                Type = "Type"

            });
            context.Planes.Add(new Plane
            {
                MaxPassengers =100,
                Model = "Mriya",
                Country = "Ukraine",
                Type = "Gryz"

            });
            context.Clients.Add(new Client
            {
                Name = "John",
                Surname = "Doe",
                PostCode = "32213",
                Gender = "Male",
                AccountId = context.Accounts.Where(a => a.Login == "Test" && a.Password == "qwerty-1").FirstOrDefault().Id,

            });
            context.Clients.Add(new Client
            {
                Name = "user",
                Surname = "test",
                PostCode = "3212413",
                Gender = "FeMale",
                AccountId = context.Accounts.Where(a => a.Login == "user" && a.Password == "test").FirstOrDefault().Id,

            });
            context.Accounts.Add(new Account
            {
                Login = "user",
                Password = "test"
            });
            context.Accounts.Add(new Account
            {
                Login = "Test",
                Password = "qwerty-1"
            });
            context.Deportations.Add(new Deportation
            {
                Number = "1",
                ArrivingDate = DateTime.Now,
                DeportDate = new DateTime (2024,3,12),
                ArrivingPlace = "Ukraine",
                DeportPlace = "USA",
                PlaneId = context.Planes.Where(p => p.Id == 1).FirstOrDefault().Id

            });
            context.SaveChanges();
           
        }
    }
}
