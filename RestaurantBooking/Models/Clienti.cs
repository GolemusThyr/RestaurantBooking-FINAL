using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models
{
    public class Clienti
    {

        public int ID { get; set; }

        [Required]
        public string NumePrenume { get; set; }

        public int IndexOras { get; set; }

        public string Email { get; set; }

        public string Parola { get; set; }

        [Required]
        public string DeviceID { get; set; }
    
        public string Token { get; set; }

    }
}