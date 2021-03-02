using Domain;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SenderApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaseController : ControllerBase
    {
        private readonly ILogger<CaseController> _logger;

        readonly IBus _bus;

        readonly IRequestClient<Case> _requestClient;

        public CaseController(ILogger<CaseController> logger, IRequestClient<Case> requestClient)
        {
            _logger = logger;
            _requestClient = requestClient;
        }

        [HttpPost("WaitResponse")]
        public async Task<ActionResult> WaitResponse([FromBody] Case value, CancellationToken cancellationToken)
        {
            var result = await _requestClient.GetResponse<Result>(value, cancellationToken);

            Console.WriteLine(result.Message.ResultCode);

            return Accepted(new { result.Message.ResultCode });
        }
    }
}
