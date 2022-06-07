using System;
using MediatR;
using MassTransit;
using System.Threading.Tasks;
using BasketFormation.Application.Features.ShoppingsCarts.Commands.CreateShoppingCart;

namespace BasketFormation.API.Consumers
{
    public class ProductsToCartConsumer : IConsumer<CreateShoppingCartCommand>
    {
        private readonly IMediator _mediator;
        public ProductsToCartConsumer(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Consume(ConsumeContext<CreateShoppingCartCommand> context)
        {
            var command = context.Message;
            
            await _mediator.Send(command);
        }
    }
}
