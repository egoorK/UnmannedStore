using System;
using MediatR;

namespace BasketFormation.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Unit>
    {
        public Guid Product_ID { get; set; }
        public string Name { get; set; }
        public decimal Unit_price { get; set; }
        public string Article_number { get; set; }
    }
}
