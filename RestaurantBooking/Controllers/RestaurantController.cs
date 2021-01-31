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
    [RoutePrefix("api/Restaurant")]
public class RestaurantController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }



        // GET api/Restaurant/Restaurante10
        [Route("Restaurante10")]
        public string GetRestaurante10([FromBody] Restaurante value)
        {
            RestaurantPersistence rp = new RestaurantPersistence();
            string rezultat = rp.Restaurante10(value);
            return rezultat;






            return " ";
        }

        // GET api/Restaurant/RestaurantIndividual
        [Route("RestaurantIndividual")]
        public string GetRestaurantIndividual([FromBody] Restaurante value)
        {
            RestaurantPersistence rp = new RestaurantPersistence();
            string rezultat = rp.IndividualRestaurant(value);
            return rezultat;






            return " ";
        }

    }


}





