using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _10_code_First
{
    public class Project
    {
        public Project()
        {
            Workers = new HashSet<Worker>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime LaunchDate { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }

}