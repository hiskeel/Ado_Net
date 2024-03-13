using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HT_5_Airport
{
    public class Deportation
    {
        public Deportation() {
            Clients = new HashSet<Client>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public int PlaneId { get; set; }
        [Required]
        public DateTime DeportDate { get; set;}
        [Required]
        public DateTime ArrivingDate { get; set;}
        [Required]
        public string DeportPlace { get; set; }
        [Required]
        public string ArrivingPlace { get; set;}

        public virtual ICollection<Client> Clients {  get; set; }
        //public virtual ICollection<Client> Clients
        //{
        //    get { return Clients; }
        //    set
        //    {
        //        if (Clients.Count <= Plane.MaxPassengers)
        //        {
        //            Clients = new HashSet<Client>();
        //        }
        //    }
        //}
        public virtual Plane Plane { get; set; }
    }

}