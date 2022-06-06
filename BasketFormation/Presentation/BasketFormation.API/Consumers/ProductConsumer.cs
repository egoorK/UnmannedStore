using System;
using MediatR;
using MassTransit;
using System.Threading.Tasks;
using BasketFormation.Infrastructure.DTOForEvents;
using BasketFormation.Application.Features.Products.Commands.CreateProduct;
using BasketFormation.Application.Features.Products.Commands.UpdateProduct;
using BasketFormation.Application.Features.Products.Commands.DeleteProduct;

namespace BasketFormation.API.Consumers
{
    public class ProductConsumer : IConsumer<ProductCommandEvent>
    {
        private readonly IMediator _mediator;

        public ProductConsumer(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Consume(ConsumeContext<ProductCommandEvent> context)
        {
            var ctx = context.Message.Event_Type;

            if (ctx == "created")
            {
                var command = new CreateProductCommand()
                {
                    Product_ID = context.Message.Product_ID,
                    Name = context.Message.Name,
                    Unit_price = context.Message.Unit_price,
                    Article_number = context.Message.Article_number
                };
                await _mediator.Send(command);
            }
            else if (ctx == "updated")
            {
                var command = new UpdateProductCommand()
                {
                    Product_ID = context.Message.Product_ID,
                    Name = context.Message.Name,
                    Unit_price = context.Message.Unit_price,
                    Article_number = context.Message.Article_number
                };
                await _mediator.Send(command);
            }
            else
            {
                var command = new DeleteProductCommand()
                {
                    Product_ID = context.Message.Product_ID
                };
                await _mediator.Send(command);
            }
        }
    }
}
