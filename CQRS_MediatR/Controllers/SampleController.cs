using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_MediatR.Base;
using CQRS_MediatR.CQRS.InputModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace CQRS_MediatR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : BaseController
    {

        public SampleController(IMediator mediator, IRedisManager redisManager) : base(mediator, redisManager) { }

        [HttpGet("[action]")]
        public async Task<IActionResult> APIWithCache([FromBody] APIWithCacheQueryInputModel inputModel) => await Execute(inputModel);
        [HttpGet("[action]")]
        public async Task<IActionResult> APIWithoutCache([FromBody] APIWithoutCacheQueryInputModel inputModel) => await Execute(inputModel);

        [HttpPost("[action]")]
        public async Task<IActionResult> API2([FromBody] API2CommandInputModel inputModel) => await Execute(inputModel);
    }
}
