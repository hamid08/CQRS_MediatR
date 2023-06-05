using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_MediatR.CQRS.InputModels
{
    public class APIWithoutCacheQueryInputModel : IRequest<string>
    {
        public string Name { get; set; }
    }
}
