using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab02Distributed.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Lab02Distributed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private RestClient client;

        public ValuesController()
        {
            client = new RestClient("http://144.17.24.145:6005");

        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            var request = new RestRequest("/register", Method.POST);
            request.AddJsonBody(new RegisterRequest()
            {
                workerId = new Guid(),
                TeamName = "ColombianBoi",
                CreateJobEndPoint = "http://144.17.24.64:5000/api/RecieveJob",
                ErrorCheckEndPoint = "http://144.17.24.64:5000/api/Error"
            });
            try
            {
              
                var response = client.Execute<CreateJobResponse>(request);
                Console.WriteLine("\n>>>" + response.Data.Result + "<<<\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return new string[] { "Works", "Works" };
        }



    }
}
