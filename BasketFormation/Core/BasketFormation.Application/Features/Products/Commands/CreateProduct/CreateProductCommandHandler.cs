using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using BasketFormation.Domain.Entities;
using BasketFormation.Application.Contracts.Persistence;

namespace BasketFormation.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken) // Реализует обработку запроса от Контроллера, переданного через Медиатор 
        {
            var productEntity = _mapper.Map<Product>(request);
            await _productRepository.AddAsync(productEntity);

            return Unit.Value;
        }
    }
}
