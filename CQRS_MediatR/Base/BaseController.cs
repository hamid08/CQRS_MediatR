using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_MediatR.Base
{
    public class BaseController : Controller
    {
        private readonly IMediator mediator;
        private readonly IRedisManager redisManager;

        public BaseController(IMediator mediator, IRedisManager redisManager)
        {
            this.mediator = mediator;
            this.redisManager = redisManager;
        }


        public async Task<IActionResult> Execute<TResponse>(IRequest<TResponse> request)
        {
            var cacheAttribute = (CachedAttribute)request.GetType().GetCustomAttributes(typeof(CachedAttribute), true).SingleOrDefault();
            if (cacheAttribute != null)
            {
                string key = CacheKeyManager.GetCacheKey(request.GetType().Name, request.Serilize());
                var response = redisManager.Get<TResponse>(key);
                if (response == null)
                {
                    response = await mediator.Send(request);
                    redisManager.Create(key, response.Serilize());
                }
                return Ok(new
                {
                    data = response,
                    status = true
                });
            }

            return Ok(new
            {
                data = await mediator.Send(request),
                status = true
            });
        }
    }
}
