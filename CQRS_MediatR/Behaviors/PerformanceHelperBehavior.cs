using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.Behaviors
{
    public class PerformanceHelperBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var response = await next();
            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds > 2000)
            {
                Console.WriteLine("API : " + request.GetType().Name + " Lapsed :" + stopwatch.ElapsedMilliseconds.ToString() + "milisecond!");
            }

            return response;
        }
    }
}
