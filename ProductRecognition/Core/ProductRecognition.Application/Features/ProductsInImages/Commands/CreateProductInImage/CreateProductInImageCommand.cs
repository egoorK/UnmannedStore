using System;
using MediatR;
using System.Collections.Generic;
using ProductRecognition.Application.DTOForEvents.ProductRecognized;

namespace ProductRecognition.Application.Features.ProductsInImages.Commands.CreateProductInImage
{
    public class CreateProductInImageCommand : IRequest<Unit>
    {
        public Guid Image_ID { get; set; }
        public List<ProductRecognizedEvent> Products { get; set; }
    }
}
