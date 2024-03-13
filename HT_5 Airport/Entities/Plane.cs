using System.ComponentModel.DataAnnotations;

namespace HT_5_Airport
{
    public class Plane
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int MaxPassengers { get; set; }
        [Required]
        public string Country { get; set; }
    }

}