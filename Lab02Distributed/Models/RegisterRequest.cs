using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02Distributed.Models
{
    public class RegisterRequest
    {
        public Guid workerId { get; set; }
        public string TeamName { get; set; }
        public string CreateJobEndPoint { get; set; }
        public string ErrorCheckEndPoint { get; set; }
    }
}
