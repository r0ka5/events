using Domain;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnotherReceiver
{
    public class ProductConsumer : IConsumer<Product>
    {
        public async Task Consume(ConsumeContext<Product> productContext)
        {
            Console.WriteLine($"Another Product received: {productContext.Message.Name}, {productContext.Message.Id}. MesageId: {productContext.MessageId}");

            if (productContext.Message.Name == "error")
                throw new Exception();
        }
    }
}
