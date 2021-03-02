using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnotherReceiver
{
    public class ProductConsumerDefinition : ConsumerDefinition<ProductConsumer>
    {
        public ProductConsumerDefinition()
        {
            // override the default endpoint name
            EndpointName = "product-processing-1";
          

            // limit the number of messages consumed concurrently
            // this applies to the consumer only, not the endpoint
            ConcurrentMessageLimit = 8;
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<ProductConsumer> consumerConfigurator)
        {
            // configure message retry with millisecond intervals
        //    endpointConfigurator.UseMessageRetry(r => r.Intervals(100, 200, 500, 800, 1000));

            // use the outbox to prevent duplicate events from being published
            endpointConfigurator.UseInMemoryOutbox();
        }

    }
}
