using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantBooking.Models
{
    /* public class ChartLoc
     {​​
     public string Category {​​ get; set; }​​
     public List<int> Data {​​ get; set; }​​
 }​*/


    public class ChartLoc
    {
        public string Category { get; set; }
        public List<string> Data { get; set; }
    }
}