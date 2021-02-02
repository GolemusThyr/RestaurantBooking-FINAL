using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantBooking.Models
{
    public class Booking
    {
        public int IndexClient { get; set; }
        public int IndexRestaurant { get; set; }
        public string Nume { get; set; }
        public string Token { get; set; }
        public string DataInceput { get; set; }
        public string DataFinal { get; set; }


        public int IndexMasa1 { get; set; }
        public int IndexMasa2 { get; set; }
        



    }
}