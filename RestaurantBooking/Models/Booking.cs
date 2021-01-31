using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantBooking.Models
{
    public class Booking
    {

        public int IndexRestaurant { get; set; }
        public string Nume { get; set; }

        public string Specific { get; set; }
        public int CategoriePret { get; set; }
        public float Scor { get; set; }
        public string Adresa { get; set; }

        public int Telefon { get; set; }

        public string Descriere { get; set; }


    }
}