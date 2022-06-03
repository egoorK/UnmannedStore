using MediatR;
using System;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Application.Contracts.Persistence;
using ProductRecognition.Application.Contracts.Infrastructure;
using ProductRecognition.Application.DTOForEvents.ProductRecognized;


namespace ProductRecognition.Application.Features.ProductsInImages.Commands.CreateProductInImage
{
    public class CreateProductInImageCommandHandler : IRequestHandler<CreateProductInImageCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductInImageRepository _productInImageRepository;
        private readonly IProductFrameRepository _productFrameRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IProductsToCartPublisher _productsToCartPublisher;

        public CreateProductInImageCommandHandler(IMapper mapper, IProductInImageRepository productInImageRepository, IProductFrameRepository productFrameRepository, IImageRepository imageRepository, IProductsToCartPublisher productsToCartPublisher)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productInImageRepository = productInImageRepository ?? throw new ArgumentNullException(nameof(productInImageRepository));
            _productFrameRepository = productFrameRepository ?? throw new ArgumentNullException(nameof(productFrameRepository));
            _imageRepository = imageRepository ?? throw new ArgumentNullException(nameof(imageRepository));
            _productsToCartPublisher = productsToCartPublisher ?? throw new ArgumentNullException(nameof(productsToCartPublisher));
        }

        public async Task<Unit> Handle(CreateProductInImageCommand request, CancellationToken cancellationToken)
        {
            var reqId = request.Image_ID;
            var reqProducts = request.Products;
            List<ProductInImage> productInImageEntity = new List<ProductInImage>(reqProducts.Count);
            List<ProductFrame> productFrameEntity = new List<ProductFrame>(reqProducts.Count);
            var productsToCart = new ProductsToCartEvent();

            foreach (var rP in reqProducts)
            {
                productInImageEntity.Add(new ProductInImage()
                {
                    ImageID = reqId,
                    ProductID = rP.Product_ID,
                    Probability_recognition = rP.Probability_recognition
                });

                productFrameEntity.Add(new ProductFrame() 
                {
                    Top_Left_Corner_Coord_X = rP.Product_frame.Top_Left_Corner_Coord_X,
                    Top_Left_Corner_Coord_Y = rP.Product_frame.Top_Left_Corner_Coord_Y,
                    Frame_Height = rP.Product_frame.Frame_Height,
                    Frame_Width = rP.Product_frame.Frame_Width
                });

                productsToCart.Products.Add(rP.Product_ID);
            }

            var result = await _productInImageRepository.AddManyAsync(productInImageEntity);
            //---
            for (int i = 0; i < productFrameEntity.Count; i++)
            {
                productFrameEntity[i].ProductInImageID = result[i];
            }

            await _productFrameRepository.AddManyAsync(productFrameEntity);
            //----

            productsToCart.Account_ID = await _imageRepository.GetAccountByIdAsync(reqId);

            await _productsToCartPublisher.SendMessageAsync(productsToCart);

            return Unit.Value;
        }
    }
}
