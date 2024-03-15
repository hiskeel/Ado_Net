using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _10_code_First
{
    [Table("Employees")]
    public class Worker
    {
        public Worker()
        {
            Projects = new HashSet<Project>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("FirstName")]
        public string Name { get; set; }
        [Column("LastName")]
        [Required]
        public string Surname { get; set; }
        [NotMapped]
        public string FullName  =>$"{Name}, {Surname}";
        public DateTime? Birthdate { get; set; }
        public decimal Salary {  get; set; }

        public int? CountryId { get; set; }
        public int DepartmentId { get; set; }

        public virtual Country Country{ get; set;}
        public virtual Department Department{ get; set;}
        public virtual ICollection<Project> Projects { get; set; }
    }

}