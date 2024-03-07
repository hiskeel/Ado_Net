using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SportShop;Integrated Security=True;Connect Timeout=2";
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            Console.WriteLine("Connected");

            //string cmdText = @"insert into Products values
            //                    ('Зошит', 'Школа', 100 , 15, 'Україна' , 30) ";
            //SqlCommand command = new SqlCommand(cmdText, connection);

            //int row = command.ExecuteNonQuery();
            //command.ExecuteScalar();
            //Console.WriteLine($"Rows affected: {row} ");
            //string cmd = "select AVG(Price) from Products";
            //SqlCommand command = new SqlCommand(cmd, connection);
            //int avg = (int)command.ExecuteScalar();
            //Console.WriteLine(avg); 

            string cmd = "select * from Products";
            SqlCommand command = new SqlCommand(cmd, connection);
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"{reader.GetName(i), 16}");
            }
            Console.WriteLine();
           
            Console.WriteLine(new string ('-',120) );
            while (reader.Read())
            {
                for(int i = 0;i < reader.FieldCount;i++) {
                    Console.Write($"{reader[i],16}");
                   
                }
                Console.WriteLine();
            }







            connection.Close();
        }
    }
}
