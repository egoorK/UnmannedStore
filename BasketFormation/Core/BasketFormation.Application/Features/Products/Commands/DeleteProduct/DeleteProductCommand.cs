using System;
using MediatR;

namespace BasketFormation.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public Guid Product_ID { get; set; }
    }
}
