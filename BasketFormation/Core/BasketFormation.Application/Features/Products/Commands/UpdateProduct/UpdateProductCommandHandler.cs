using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using BasketFormation.Domain.Entities;
using BasketFormation.Application.Contracts.Persistence;

namespace BasketFormation.Application.Features.Products.Commands.UpdateProduct
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

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<Product>(request);
            await _productRepository.UpdateAsync(productEntity);

            return Unit.Value;
        }
    }
}
