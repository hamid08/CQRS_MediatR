using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_MediatR.Base
{
    public static class StringExtentions
    {
        public static string Serilize(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
