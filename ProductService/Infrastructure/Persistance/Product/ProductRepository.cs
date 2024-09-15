using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Core.Entities.Product> CreateProductAsync(Core.Entities.Product product, CancellationToken cancellationToken = default)
        {
            var newProduct = await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync();
            return newProduct.Entity;
        }

        public async Task<Core.Entities.Product?> GetProductAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}