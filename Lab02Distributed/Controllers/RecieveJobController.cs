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
    public class RecieveJobController : ControllerBase
    {
        public OrderOfOperations _orderOfOperations;

        public RecieveJobController(OrderOfOperations orderOfOperations)
        {
            _orderOfOperations = orderOfOperations;
        }

        [HttpPost]
        public CreateJobResponse Post([FromBody] CreateJobRequest Job)
        {
            //"CALCULATE: 675 / 518"
            var problem = Job.Calculation.Replace("CALCULATE: ", "");
            var problem2 = Job.Calculation.Replace(" ", "");
            decimal answer = 0;
            answer = decimal.Round(_orderOfOperations.brackets(problem2), 3);


            var p = problem.Split(' ');


            


            //var firstInt = int.Parse(p[0]);
            //var secondInt = int.Parse(p[2]);
            //switch (p[1])
            //{
            //    case "+":
            //        answer = firstInt + secondInt;
            //        break;
            //    case "-":
            //        answer = firstInt - secondInt;
            //        break;
            //    case "*":
            //        answer = firstInt * secondInt;
            //        break;
            //    case "/":
            //        if (secondInt != 0)
            //            answer = decimal.Round(firstInt / (decimal)secondInt, 3);
            //        break;
            //}

            return new CreateJobResponse
            {
                JobId = Job.JobId,
                Result = answer.ToString()
            };
        }

    }
}
