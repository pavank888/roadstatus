using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadStatus.Entities
{
    public class ApiError
    {
        public string HttpStatusCode { get; set; }

        public string ExceptionType { get; set; }
        public string Message { get; set; }
    }
}
