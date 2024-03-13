using System.ComponentModel.DataAnnotations;

namespace HT_5_Airport
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual Client Client { get; set; }
    }

}