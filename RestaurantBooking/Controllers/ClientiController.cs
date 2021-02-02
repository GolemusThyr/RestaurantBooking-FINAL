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
    [RoutePrefix("api/Clienti")]
    public class ClientiController : ApiController
    {
       






        // GET: api/Clienti
        public IEnumerable<string> Get()
        {
            return new string[] { "Client 1", "Client 2" };
        }

        // GET: api/Clienti/5
        public Clienti Get(int id)
        {
            Clienti client = new Clienti();

            //return "Un client";
            return client;
        }

        // POST: api/Clienti/Register
        [Route("Register")]
        public string Post([FromBody]Clienti value)
        {
            ClientiPersistence cp = new ClientiPersistence();
            //int id;
            //id = cp.saveClient(value);
            //value.ID = id;
            string clientReg = cp.saveClient(value);

            
            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            //response.Headers.Location = new Uri(Request.RequestUri, string.Format("client"));
            System.Diagnostics.Debug.WriteLine("Token: " + value.Token);
            System.Diagnostics.Debug.WriteLine("ClientReg:" + clientReg);
            return clientReg;

        }

       
    
    
    }
}