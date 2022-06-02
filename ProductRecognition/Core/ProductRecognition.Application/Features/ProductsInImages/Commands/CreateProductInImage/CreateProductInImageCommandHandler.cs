using MediatR;
using System;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Application.Contracts.Persistence;


namespace ProductRecognition.Application.Features.ProductsInImages.Commands.CreateProductInImage
{
    public class CreateProductInImageCommandHandler : IRequestHandler<CreateProductInImageCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductInImageRepository _productInImageRepository;
        private readonly IProductFrameRepository _productFrameRepository;

        public CreateProductInImageCommandHandler(IMapper mapper, IProductInImageRepository productInImageRepository, IProductFrameRepository productFrameRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productInImageRepository = productInImageRepository ?? throw new ArgumentNullException(nameof(productInImageRepository));
            _productFrameRepository = productFrameRepository ?? throw new ArgumentNullException(nameof(productFrameRepository));
        }

        public async Task<Unit> Handle(CreateProductInImageCommand request, CancellationToken cancellationToken)
        {
            var reqId = request.Image_ID;
            var reqProducts = request.Products;
            List<ProductInImage> productInImageEntity = new List<ProductInImage>(reqProducts.Count);
            List<ProductFrame> productFrameEntity = new List<ProductFrame>(reqProducts.Count);

            foreach (var rP in reqProducts)
            {
                productInImageEntity.Add(new ProductInImage()
                {
                    ImageID = reqId,
                    ProductID = rP.Product_ID,
                    Probability_recognition = rP.Probability_recognition
                });
            }

            var result = await _productInImageRepository.AddManyAsync(productInImageEntity);

            /// Добавить в сущность для хранения рамок изображений координаты Х и Y

            var productEntity = _mapper.Map<Product>(request);
            await _productRepository.AddManyAsync(productEntity);

            return Unit.Value;
        }
    }
}
