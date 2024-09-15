using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Repositories;
using Application.Mappers;
using Core.Entities;
using MediatR;

namespace Application.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var domainEntity = request.ToDomainEntity();
            domainEntity.Id = new Guid();
            var persistedProduct = await _productRepository.CreateProductAsync(domainEntity, cancellationToken);
            return persistedProduct;
        }
    }

    public record CreateProductCommand(string Name, decimal Price, int Quantity) : IRequest<Product>;
}