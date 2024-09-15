using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Application.Common.Repositories;
using Core.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {

        private readonly IProductRepository _productRepository;
        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductAsync(request.Id, cancellationToken);
            return product;
        }
    }


    public record GetProductByIdQuery(Guid Id) : IRequest<Product>;
}