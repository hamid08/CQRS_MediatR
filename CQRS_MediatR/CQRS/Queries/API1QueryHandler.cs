using CQRS_MediatR.Base;
using CQRS_MediatR.CQRS.InputModels;
using CQRS_MediatR.CQRS.ViewModels;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.CQRS.Queries
{
    public class API1QueryHandler : IRequestHandler<APIWithCacheQueryInputModel, string>,
         IRequestHandler<APIWithoutCacheQueryInputModel, string>
    {
        public async Task<string> Handle(APIWithCacheQueryInputModel request, CancellationToken cancellationToken)
        {
            await Task.Delay(2000);
            return "Hello " + request.Name;
        }

        public async Task<string> Handle(APIWithoutCacheQueryInputModel request, CancellationToken cancellationToken)
        {
            await Task.Delay(2000);
            return "Hello " + request.Name;
        }
    }
}
