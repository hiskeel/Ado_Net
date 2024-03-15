using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_code_First
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoftServeDB context = new SoftServeDB();

            //context.Countries.Add(new Country { Name = "Ukraine" });
            //context.Countries.Add(new Country { Name = "USA" });
            //context.Countries.Add(new Country { Name = "Poland" });
            //context.Departments.Add(new Department { Name = "Rockstar South" });
            //context.Departments.Add(new Department { Name = "Rockstar Sandiego" });
            //context.Departments.Add(new Department { Name = "Rockstar East" });



            //context.Workers.Add(new Worker
            //{
            //    Name = "Mykola",
            //    Surname = "Borovets",
            //    Salary = 10000,
            //    Birthdate = new DateTime(2000, 10, 27),
            //    CountryId = context.Countries.Where(c => c.Name == "Ukraine").First().Id,
            //    DepartmentId = context.Departments.Where(c => c.Name == "Rockstar Sandiego").First().Id

            //});
            //context.Workers.Add(new Worker
            //{
            //    Name = "Arthur",
            //    Surname = "Morgan",
            //    Salary = 5000,
            //    Birthdate = new DateTime(1856, 10, 27),
            //    CountryId = context.Countries.Where(c => c.Name == "USA").First().Id,
            //    DepartmentId = context.Departments.Where(c => c.Name == "Rockstar East").First().Id

            //});
            //context.Workers.Add(new Worker
            //{
            //    Name = "Bobr",
            //    Surname = "Kurwa",
            //    Salary = 2000,
            //    Birthdate = new DateTime(2003, 11, 27),
            //    CountryId = context.Countries.Where(c => c.Name == "Poland").First().Id,
            //    DepartmentId = context.Departments.Where(c => c.Name == "Rockstar South").First().Id

            //});
            //context.Workers.Add(new Worker
            //{
            //    Name = "Optimus",
            //    Surname = "Prime",
            //    Salary = 3000,
            //    Birthdate = new DateTime(2000, 1, 21),
            //    CountryId = context.Countries.Where(c => c.Name == "USA").First().Id,
            //    DepartmentId = context.Departments.Where(c => c.Name == "Rockstar Sandiego").First().Id

            //});

            //context.Projects.Add(new Project
            //{
            //    Name = "RDR 2",
            //    LaunchDate = new DateTime(2012, 1, 1),
            //});
            //context.Projects.Add(new Project
            //{
            //    Name = "Frostpunk",
            //    LaunchDate = new DateTime(2016, 1, 1),
            //});
            //context.Projects.Add(new Project
            //{
            //    Name = "Dota 2",
            //    LaunchDate = new DateTime(2011, 1, 1),
            //});

            //Worker worker1 = context.Workers.Where(n => n.Name == "Mykola" && n.Surname == "Borovets").FirstOrDefault();
            //Worker bobr = context.Workers.Where(n => n.Name == "Bobr" && n.Surname == "Kurwa").FirstOrDefault();
            //Worker optimus = context.Workers.Where(n => n.Name == "Optimus" && n.Surname == "Prime").FirstOrDefault();

            //Project project1 = context.Projects.Where(n => n.Name == "RDR 2").FirstOrDefault();
            //Project dota = context.Projects.Where(n => n.Name == "Dota 2").FirstOrDefault();
            //Project frpunk = context.Projects.Where(n => n.Name == "Frostpunk").FirstOrDefault();

            //worker1.Projects.Add(project1);
            //bobr.Projects.Add(project1);
            //optimus.Projects.Add(dota);
            //optimus.Projects.Add(project1);
            //bobr.Projects.Add(dota);
            //worker1.Projects.Add(frpunk);
            //bobr.Projects.Add(frpunk);
            //optimus.Projects.Add(frpunk);


            //context.SaveChanges();

            //foreach(var i in context.Workers) 
            //{
            //    Console.WriteLine($"-----------User[{i.Id}] {i.FullName}");
            //    Console.WriteLine($"\tDepartment: {i.Department.Name} {i.Salary}");
            //    Console.WriteLine($"\tBirthdate: {(i.Birthdate.HasValue ? i.Birthdate.Value.ToShortDateString() : "No Birthdate")}");

            //}

            foreach (var w in context.Workers)
            {
                Console.WriteLine($"-----------User[{w.Id}] {w.FullName}");
                Console.WriteLine($"\tDepartment: {w.Department.Name} {w.Salary}");
                if (w.CountryId != null)
                {
                    Console.WriteLine($"\t Country: {w.Country.Name}");
                }
                foreach (var p in w.Projects)
                {
                    Console.WriteLine($"\t Project: {p.Name}");
                }
            }


        }
    }
}
