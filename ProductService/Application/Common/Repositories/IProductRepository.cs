using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.Common.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> GetProductAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
        public Task<Product?> CreateProductAsync(Product product, CancellationToken cancellationToken = default(CancellationToken));
    }
}