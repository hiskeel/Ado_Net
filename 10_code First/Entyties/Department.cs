using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _10_code_First
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public string Name { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
        public Department()
        {
            Workers = new HashSet<Worker>();
        }
    }

}