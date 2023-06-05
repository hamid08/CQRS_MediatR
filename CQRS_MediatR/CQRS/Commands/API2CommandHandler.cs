using CQRS_MediatR.Base;
using CQRS_MediatR.CQRS.InputModels;
using MediatR;
using ServiceStack.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.CQRS.Commands
{
    public class API2CommandHandler : IRequestHandler<API2CommandInputModel, bool>
    {
        private readonly IRedisManager redisManager;

        public API2CommandHandler(IRedisManager redisManager)
        {
            this.redisManager = redisManager;
        }
        public async Task<bool> Handle(API2CommandInputModel request, CancellationToken cancellationToken)
        {
            redisManager.DeleteApiCache(typeof(APIWithCacheQueryInputModel));
            return true;
        }
    }
}
