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
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly ICartContentsRepository _cartContentsRepository;

        public CreateShoppingCartCommandHandler(IProductRepository productRepository, IShoppingCartRepository shoppingCartRepository, ICartContentsRepository cartContentsRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _shoppingCartRepository = shoppingCartRepository ?? throw new ArgumentNullException(nameof(shoppingCartRepository));
            _cartContentsRepository = cartContentsRepository ?? throw new ArgumentNullException(nameof(cartContentsRepository));
        }

        public async Task<Unit> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            Guid spgCartId = new Guid("000c0000-c00c-0c00-00c0-cc0c0c000cc0");
            var reqId = request.Account_ID;
            var reqProd = request.Products;

            var shoppingCart = await _shoppingCartRepository.FindShoppingCartAsync(reqId);
            if (shoppingCart != null)
            {
                spgCartId = shoppingCart.ShoppingCart_ID;
            }
                
            foreach (var rP in reqProd)
            {
                if (shoppingCart == null && spgCartId == new Guid("000c0000-c00c-0c00-00c0-cc0c0c000cc0"))
                {
                    var spgCart = new ShoppingCart()
                    {
                        Fill_start_time = DateTime.UtcNow,
                        AccountID = reqId
                    };

                    spgCartId = await _shoppingCartRepository.AddAsync(spgCart);

                    var cartContnsFirst = new CartContents()
                    {
                        Quantity = 1,
                        Price_incl_quantity = await _productRepository.GetPriceAsync(rP),
                        Item_number_in_cart = 1,
                        ProductID = rP,
                        ShoppingCartID = spgCartId
                    };

                    await _cartContentsRepository.AddAsync(cartContnsFirst);
                    continue;
                }

                var crtCntnts = await _cartContentsRepository.GetCartContents(rP, spgCartId);

                if (crtCntnts == null)
                {
                    var maxItemNumber = await _cartContentsRepository.GetItemNumber(spgCartId); // Не изменился порядковый номер в корзине

                    var cartContnsFirstt = new CartContents()
                    {
                        Quantity = 1,
                        Price_incl_quantity = await _productRepository.GetPriceAsync(rP),
                        Item_number_in_cart = ++maxItemNumber,
                        ProductID = rP,
                        ShoppingCartID = spgCartId
                    };

                    await _cartContentsRepository.AddAsync(cartContnsFirstt);
                    continue;
                }

                var qnt = crtCntnts.Quantity;
                crtCntnts.Quantity = ++qnt;
                crtCntnts.Price_incl_quantity = qnt * (await _productRepository.GetPriceAsync(rP));

                await _cartContentsRepository.UpdateAsync(crtCntnts);
            }

            var totalCost = await _cartContentsRepository.GetTotalCost(spgCartId);
            var shpngCart = new ShoppingCart() 
            {
                ShoppingCart_ID = spgCartId,
                Total_without_discount = totalCost
            };

            await _shoppingCartRepository.UpdateAsync(shpngCart);

            // Сформировать структуру данных для отправки к клиенту.
            // Использовать следующие поля из таблиц Товары и Содержимое корзин:
            // Учетная_запись_ID, Товар_ID, Наименование, Цена за единицу, Количество, Цена с учетом количества, Номер позиции в корзине.


            return Unit.Value;
        }
    }
}
