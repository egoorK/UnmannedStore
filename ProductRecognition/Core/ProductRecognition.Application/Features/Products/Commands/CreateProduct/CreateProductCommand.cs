using System;
using MediatR;

namespace ProductRecognition.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Unit>
    {
        public Guid Product_ID { get; set; }
        public string Name { get; set; }
    }
}
