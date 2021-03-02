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
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        readonly IBus _bus;
        public ProductController(ILogger<ProductController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product value, CancellationToken cancellationToken)
        {
            await _bus.Send<Product>(new Product
            {
                Name = value.Name,
                Id = Guid.NewGuid().ToString()
            }, cancellationToken) ;

            return Ok();
        }

        [HttpPost("PostAll")]
        public async Task<ActionResult> PostAll([FromBody] Product value, CancellationToken cancellationToken)
        {
            await _bus.Publish<Product>(new Product
            {
                Name = value.Name,
                Id = Guid.NewGuid().ToString()
            }, cancellationToken);

            return Ok();
        }

        [HttpPost("WaitResponse")]
        public async Task<ActionResult> WaitResponse([FromBody] Product value, CancellationToken cancellationToken)
        {
            await _bus.Publish<Product>(new Product
            {
                Name = value.Name,
                Id = Guid.NewGuid().ToString()
            }, cancellationToken);

            return Ok();
        }
    }
}
