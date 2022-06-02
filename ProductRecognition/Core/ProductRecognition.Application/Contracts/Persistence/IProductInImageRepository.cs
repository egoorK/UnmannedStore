using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProductRecognition.Domain.Entities;

namespace ProductRecognition.Application.Contracts.Persistence
{
    public interface IProductInImageRepository
    {
        Task<IReadOnlyList<Guid>> AddManyAsync(List<ProductInImage> entities);
    }
}
