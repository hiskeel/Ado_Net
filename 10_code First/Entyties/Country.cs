using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _10_code_First
{
    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }

        public Country()
        {
            Workers = new HashSet<Worker>();
        }
    }

}