using CQRS_MediatR.Base;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.Behaviors
{
    public class EventSourcingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IRedisManager redisManager;
        private readonly ILogger<EventSourcingBehavior<TRequest, TResponse>> logger;

        public EventSourcingBehavior(IRedisManager redisManager,ILogger<EventSourcingBehavior<TRequest, TResponse>> logger)
        {
            this.redisManager = redisManager;
            this.logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();

            if (request.GetType().Name.Contains("Command"))
            {
                var eventData = new EventData
                {
                    APIName = request.GetType().Name,
                    Date = DateTime.Now,
                    Request = request.Serilize(),
                    Response = response.Serilize()
                };
                if (!redisManager.CreateEventSourcing(eventData))
                    logger.LogError("Event Sorcing Error Save!", eventData.Serilize());
            }

            return response;
        }
    }
}
