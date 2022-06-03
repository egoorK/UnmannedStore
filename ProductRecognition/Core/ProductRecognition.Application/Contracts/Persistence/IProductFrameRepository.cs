using System.Threading.Tasks;
using System.Collections.Generic;
using ProductRecognition.Domain.Entities;

namespace ProductRecognition.Application.Contracts.Persistence
{
    public interface IProductFrameRepository
    {
        Task AddManyAsync(List<ProductFrame> entities);
    }
}
