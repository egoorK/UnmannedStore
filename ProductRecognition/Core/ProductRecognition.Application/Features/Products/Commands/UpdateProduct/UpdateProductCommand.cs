using System;
using MediatR;

namespace ProductRecognition.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public Guid Product_ID { get; set; }
        public string Name { get; set; }
    }
}
