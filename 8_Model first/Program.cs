using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Model_first
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryModeContainer content = new LibraryModeContainer();
            content.Authors.Add(new Author
            {
                Name = "Stiven",
                Birthday = DateTime.Now,
            });
            content.Books.Add(new Book { 
                Name ="Title"}
          );
            content.SaveChanges();
            

        }
    }
}
