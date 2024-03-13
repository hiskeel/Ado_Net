using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HT_5_Airport
{
    public class Client
    {
        public Client()
        {
            Deportations = new HashSet<Deportation>();

        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string PostCode { get; set; }
        [Required]
        public string Gender { get; set; }
        [NotMapped]
        public string FullName => $"{Name} {Surname}";
        [Required]
        public int AccountId {  get; set; }
        public virtual ICollection<Deportation> Deportations { get; set; }
        public virtual Account Account { get; set; }


    }

}