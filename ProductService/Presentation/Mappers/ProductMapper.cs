using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Core.Entities;
using Presentation.Contracts;

namespace Presentation.Mappers
{
    public static class ProductMapper
    {
        public static ProductByIdResponse ToApiResponse(this Product product)
        {
            return new ProductByIdResponse
            {

                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
            };
        }

        public static CreateProductCommand ToCommand(this CreateProductRequest request) => new CreateProductCommand(request.Name, request.Price, request.Quantity);

        public static CreateProductResponse ToApiResponseFromCommand(this Product product)
        {
            return new CreateProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }
    }


}