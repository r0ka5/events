using Domain;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receiver
{
    public class ProductConsumer : IConsumer<Product>
    {
        public async Task Consume(ConsumeContext<Product> productContext)
        {
            Console.WriteLine($"Product received: {productContext.Message.Name}, {productContext.Message.Id}. MesageId: {productContext.MessageId}");

            if (productContext.Message.Name == "error")
                throw new Exception();
        }
    }
}
