using MediatR;
using System;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Application.Contracts.Persistence;

namespace ProductRecognition.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken) // Реализует обработку запроса от Контроллера, переданного через Медиатор 
        {
            var productEntity = _mapper.Map<Product>(request);
            await _productRepository.DeleteAsync(productEntity.Product_ID);

            return Unit.Value;
        }
    }
}
