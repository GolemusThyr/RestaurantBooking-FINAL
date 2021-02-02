using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestaurantBooking.Models;
using System.Web;


namespace RestaurantBooking.Controllers
{
    public class BookingController : ApiController
    {
        public string Post([FromBody] Booking value)
        {
            BookingPersistence bp = new BookingPersistence();
            //int id;
            //id = cp.saveClient(value);
            //value.ID = id;
            string bookingReg = bp.saveBooking(value);


            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            //response.Headers.Location = new Uri(Request.RequestUri, string.Format("client"));
           
            return bookingReg;
        }
    }
}