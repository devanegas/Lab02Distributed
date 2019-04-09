using Lab02Distributed.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02Distributed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpPost]
        public void Error([FromBody] ErrorCheckResponse error)
        {
            Console.WriteLine("Error received");
        }
    }
}
