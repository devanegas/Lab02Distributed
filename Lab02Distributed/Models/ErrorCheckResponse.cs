using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02Distributed.Models
{
    public class ErrorCheckResponse
    {
        public Guid JobId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
