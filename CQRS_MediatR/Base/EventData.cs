using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_MediatR.Base
{
    public class EventData
    {
        public string APIName { get; set; }
        public DateTime Date { get; set; }
        public string Response { get; set; }
        public string Request { get; set; }
    }
}
