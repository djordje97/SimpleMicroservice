using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Core.Entities;

namespace Application.Mappers
{
    public static class ProductMapper
    {
        public static Product ToDomainEntity(this CreateProductCommand command)
        {
            return new Product
            {
                Name = command.Name,
                Price = command.Price,
                Quantity = command.Quantity,
            };
        }
    }
}