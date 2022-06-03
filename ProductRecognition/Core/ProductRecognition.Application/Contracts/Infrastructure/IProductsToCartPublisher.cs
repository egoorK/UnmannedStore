using System.Threading.Tasks;
using ProductRecognition.Application.DTOForEvents.ProductRecognized;

namespace ProductRecognition.Application.Contracts.Infrastructure
{
    public interface IProductsToCartPublisher
    {
        Task SendMessageAsync(ProductsToCartEvent entity);
    }
}
