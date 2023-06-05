using CQRS_MediatR.Base;
using CQRS_MediatR.CQRS.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_MediatR.CQRS.InputModels
{
    [Cached]
    public class APIWithCacheQueryInputModel : IRequest<string>
    {
        public string Name { get; set; }
    }
}
