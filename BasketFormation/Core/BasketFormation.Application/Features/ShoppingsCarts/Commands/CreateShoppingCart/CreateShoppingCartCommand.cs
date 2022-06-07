using System;
using MediatR;
using System.Collections.Generic;

namespace BasketFormation.Application.Features.ShoppingsCarts.Commands.CreateShoppingCart
{
    public class CreateShoppingCartCommand : IRequest<Unit>
    {
        public CreateShoppingCartCommand()
        {
            this.Products = new List<Guid>();
        }
        public Guid Account_ID { get; set; }
        public List<Guid> Products { get; set; }
    }
}
