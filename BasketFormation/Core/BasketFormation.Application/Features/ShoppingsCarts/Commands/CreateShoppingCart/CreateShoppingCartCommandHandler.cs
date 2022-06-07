using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using BasketFormation.Domain.Entities;
using BasketFormation.Application.Contracts.Persistence;

namespace BasketFormation.Application.Features.ShoppingsCarts.Commands.CreateShoppingCart
{
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, Unit>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
      //  private readonly ICartContentsRepository _cartContentsRepository;

        public CreateShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository)//ICartContentsRepository cartContentsRepository)
        {
            _shoppingCartRepository = shoppingCartRepository ?? throw new ArgumentNullException(nameof(shoppingCartRepository));
            //_cartContentsRepository = cartContentsRepository ?? throw new ArgumentNullException(nameof(cartContentsRepository));
        }

        public async Task<Unit> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var reqId = request.Account_ID;

            var shoppingCart = await _shoppingCartRepository.FindShoppingCartAsync(reqId);
            var spgCartId = shoppingCart.ShoppingCart_ID;

            if (shoppingCart == null)
            {
                var spgCart = new ShoppingCart()
                {
                    Fill_start_time = DateTime.UtcNow,
                    AccountID = reqId
                };

                spgCartId = await _shoppingCartRepository.AddAsync(spgCart);
            }
            



            return Unit.Value;
        }
    }
}
