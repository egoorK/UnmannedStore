using MediatR;
using System;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Application.Contracts.Persistence;

namespace ProductRecognition.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken) // Реализует обработку запроса от Контроллера, переданного через Медиатор 
        {
            var productEntity = _mapper.Map<Product>(request);
            await _productRepository.UpdateAsync(productEntity);

            return Unit.Value;
        }
    }
}
