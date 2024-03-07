using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static _1_ht_1.Program;

namespace _1_ht_1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            string conn = ConfigurationManager.ConnectionStrings["connSportShop"].ConnectionString;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            bool exit = false;
            while (!exit) {
                Console.WriteLine("1. Відобразити інформацію про всіх покупців\r\n2. Відобразити інформацію про всіх продавців\r\n3. Відобразити інформацію про продажі, які виконав певний продавець по імені\r\nта прізвищу\r\n4. Відобразити інформацію про продажі на суму більше зазначеної\r\n5. Відобразити найдорожчу та найдешевшу покупку певного покупця по імені та\r\nпрізвищу\r\n6. Показати найпершу продажу певного продавця по імені та прізвищу\n0. Вихід");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        ShowClients(connection);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        ShowEmployees(connection); 
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Введіть Повне ім'я продавця Щоб побачити його продажі:"); // Full Name because there is no separeted colums with name and Surname
                        string name = Console.ReadLine();
                        ShowSalesOfEmployee(connection, name);
                        Console.ReadKey();
                        Console.Clear(); 
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Введіть мінімальну ціну товару які будуть виведені: ");
                        int cost = int.Parse(Console.ReadLine());
                        ShowSalesCostMoreThan(connection, cost);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Введіть Повне ім'я Покупця щоб дізнатись його найдорожчу та найдешевшу покупку:"); // Full Name because there is no separeted colums with name and Surname
                        name = Console.ReadLine();
                        ShowMoreAndLessExpensivePurshaceOfClient(connection, name);
                        Console.ReadKey();
                        Console.Clear(); 
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Введіть Повне ім'я продавця якого ви хочете дізнатись першу покупку:"); // Full Name because there is no separeted colums with name and Surname
                        name = Console.ReadLine();
                        ShowFirstSaleOfEmployee(connection, name);
                        Console.ReadKey();
                        Console.Clear(); break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Bye!");
                        Console.ReadKey();
                        exit = true;
                        break;
                    default: Console.WriteLine("Wrong Choice"); break;
                }

            }
           
            connection.Close();



        }

        private static void ShowSalesCostMoreThan(SqlConnection connection, int cost) {
            string cmdText = "select * from Salles where Price > @cost";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.Add("@cost", System.Data.SqlDbType.Int).Value = cost;
            SqlDataReader reader = cmd.ExecuteReader();
            ShowInfo(reader, 10);
            reader.Close();
        }
        private static void ShowMoreAndLessExpensivePurshaceOfClient(SqlConnection connection, string name)
        {
            string cmdText = "SELECT c.FullName AS ClientName,\r\nMAX(s.Price) AS MaxPurchasePrice,\r\nMIN(s.Price) AS MinPurchasePrice\r\nFROM Clients c\r\nJOIN Salles s ON c.Id = s.ClientId where @name = c.FullName\r\nGROUP BY c.FullName ";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = name;
            SqlDataReader reader = cmd.ExecuteReader();
            ShowInfo(reader, 10);
            reader.Close();

        }
        private static void ShowFirstSaleOfEmployee(SqlConnection connection, string name)
        {
            string cmdText = "select TOP 1 s.Id,s.ProductId, s.Price ,s.EmployeeId, s.ClientId,s.Quantity, s.SaleDate from Salles s \r\njoin Employees e on e.Id = s.EmployeeId \r\nwhere e.FullName = @name \r\norder by SaleDate asc";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = name;
            SqlDataReader reader = cmd.ExecuteReader();
            ShowInfo(reader, 10);
            reader.Close();
        }
        private static void ShowSalesOfEmployee(SqlConnection connection, string name)
        {
            string cmdText = "select s.Id,s.ProductId, s.Price ,s.EmployeeId, s.ClientId,s.Quantity, s.SaleDate from Salles s \r\njoin Employees e on e.Id = s.EmployeeId \r\nwhere e.FullName = @name";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = name;
            SqlDataReader reader = cmd.ExecuteReader();
            ShowInfo(reader, 10);
            reader.Close();
        }
        private static void ShowInfo(SqlDataReader reader, int book)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"{reader.GetName(i),-20}");
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', book*2+120));
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader[i],-20}");

                }
                Console.WriteLine();
            }
        }
        private static void ShowEmployees(SqlConnection conn)
        {
            int bookPlace = 25;
            string cmdText = "select * from Employees";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            ShowInfo(reader, bookPlace);
            reader.Close();



        }
        private static void ShowClients(SqlConnection conn)
        {
            int bookPlace = 30;
            string cmdText = "select * from Clients";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            ShowInfo(reader, bookPlace);
            reader.Close();


        }
    }
}