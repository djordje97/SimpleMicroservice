using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastEndpoints;
using FluentValidation;
using Presentation.Contracts;

namespace Presentation.Validators
{
    public class CreateProductValidator : Validator<CreateProductRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty()
                                            .NotNull()
                                            .WithMessage("Name is required.");
            RuleFor(product => product.Quantity).NotEmpty().GreaterThan(1);
            RuleFor(product => product.Price).NotEmpty().GreaterThan(1);
        }
    }
}